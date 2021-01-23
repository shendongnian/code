    using System;
    using System.Linq;
    
    namespace FileToHex
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] bytesFile = System.IO.File.ReadAllBytes(@"C:\temp\FileToHex\ex.tiff");
    
                string hex = BitConverter.ToString(bytesFile);
    
                //get only the first 16 hexadecimal numbers
    
                string[] header = hex.Split(new Char[] { '-' }).Take(16).ToArray();
    
                Console.WriteLine(System.String.Join("", header));
    
                Console.ReadLine();
    
            }
        }
    }
