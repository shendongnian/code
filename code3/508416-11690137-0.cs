    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace TestZoned
    {
      class Program
      {
        public static String zoneToString(byte[] zoneBytes)
        {
            Encoding ascii = Encoding.ASCII;
            Encoding ebcdic = Encoding.GetEncoding("IBM037");
            byte[] asciiBytes = null;
            String str = null;
            int zoneLen = zoneBytes.Length;
            int i = zoneLen - 1;
            int b1 = zoneBytes[i];
            b1 = (b1 & 0xf0) >> 4;
            switch (b1)
            {
                case 13:
                case 10:
                    zoneBytes[i] = (byte)(zoneBytes[i] | 0xf0);
                    asciiBytes = Encoding.Convert(ebcdic, ascii, zoneBytes);
                    str = "-" + ASCIIEncoding.ASCII.GetString(asciiBytes);
                    break;
                default:
                    zoneBytes[i] = (byte)(zoneBytes[i] | 0xf0);
                    asciiBytes = Encoding.Convert(ebcdic, ascii, zoneBytes);
                    str = ASCIIEncoding.ASCII.GetString(asciiBytes);
                    break;
            }
            return (str);
        }
        static void Main(string[] args)
        {
            byte[] array = 	{ 0xf0, 0xf0, 0xf1 }; // 001
            byte[] pos = { 0xf1, 0xf2, 0xf3, 0xf4, 0xf5, 0xf6, 0xf7, 0xf8, 0xf9 }; // 123456789
            byte[] neg = { 0xf1, 0xf2, 0xf3, 0xf4, 0xf5, 0xf6, 0xf7, 0xf8, 0xd9 }; // -123456789
            Console.WriteLine("Converted: {0}", zoneToString(array));
            Console.WriteLine("Converted: {0}", zoneToString(pos));
            Console.WriteLine("Converted: {0}", zoneToString(neg));
        }
    }
