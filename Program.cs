using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_1_Asterix
{
    public struct dataRecord_struct
    {
        public int cat { get; set; }
        public int longitud { get; set; }
        public byte[] fspec { get; set; }
        public byte[] datos { get; set; }
    }

    public struct trackInfo_struct
    {
        public int SAC { get; set; }
        public int SIC { get; set; }

        public double time { get; set; }

        public int TYP { get; set; }
        public Boolean simulated { get; set; }
        public Boolean RDP_chain2 { get; set; }
        public Boolean SPI { get; set; }
        public Boolean fieldMonitor { get; set; }
        public Boolean testTarget { get; set; }
        public Boolean extendedRange { get; set; }
        public Boolean xPulse { get; set; }
        public Boolean military { get; set; }
        public int FOE_FRI { get; set; }
        //public Boolean simulated { get; set; }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lectura del archivo en curso...");

            string path;

            path = "C:/Users/guzma/Desktop/230502-est-080001_BCN.ast";

            byte[] fileBytes = File.ReadAllBytes(path);
            List<dataRecord_struct> listaDataRecords = new List<dataRecord_struct>();

            int direccionDataRecordProcesando= 0; //Almacenará en todo momento la posición en la que empieza el siguiente Data Record en procesamiento (posición en bytes, que
                                                  //contendrá la Categoría)
            int categoriaActual = -1;
            int longitudDataRecordProcesando = fileBytes[2]; //En el caso del primer data record estará aquí ¡¡¡Pensar una forma en que me lea los dos bytes del length!!!
            int longitud_fichero = fileBytes.Length;
            Console.WriteLine($"Longitud del primer data record: {longitudDataRecordProcesando}");
            Console.WriteLine($"Longitud del fichero: {longitud_fichero}");

            while (direccionDataRecordProcesando < fileBytes.Length) //Nos permite crear una lista con todos los data records de la categoría 48
            {
                //Antes de añadir el data record nos cercioraremos que pertenezca a la categoría 48
                categoriaActual = fileBytes[direccionDataRecordProcesando];
                if (categoriaActual == 48)
                {
                    Console.WriteLine($"Aceptado: data record de categoría: {categoriaActual}");

                    //Recuperamos todos los bytes del data record
                    /*
                    byte[] dataRecord = new byte[longitudDataRecordProcesando];
                    for (int j = 0; j < dataRecord.Length; j++)
                    {
                        dataRecord[j] = fileBytes[direccionDataRecordProcesando+j];
                    }*/

                    //Primero de todo averiguamos la longitud del FSPEC


                    //Recuperamos todos los bytes del FSPEC
                    byte[] fspecActual = new byte[0];
                    int j = 0;
                    Boolean sigue = true;/*
                    while (sigue)
                    {
                        fspecActual[j] = fileBytes[direccionDataRecordProcesando + 3 + j];
                        if (j % 7 == 0) //Estudiamos el bit 
                        {
                            Console.WriteLine("La división de j entre 7 no tiene residuo.");
                        }
                        j++;
                    }

                    dataRecord_struct item = new dataRecord_struct();

                    item.cat = categoriaActual;
                    item.longitud = longitudDataRecordProcesando;
                    item.datos = dataRecord;

                    listaDataRecords.Add(item);*/
                    
                }
                else //Este else irá fuera por términos de velocidad
                { 
                    Console.WriteLine($"Denegado: data record de categoría: {categoriaActual}");
                    Console.WriteLine($"Saltando al siguiente data record...");
                }
                //Console.WriteLine($"Tamaño de lista de dataRecords: {listaDataRecords.Count}"); línea para controlar cómo se llena la lista
                direccionDataRecordProcesando = direccionDataRecordProcesando + longitudDataRecordProcesando + 1;
            }
            int i = 0;
            while (i< listaDataRecords.Count) //Recorremos la lista de data records y los almacenamos en su estructura
            {

            }
        }
    }
}
