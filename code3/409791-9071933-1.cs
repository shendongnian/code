    using System;
    using System.Linq;
    using System.IO;
    
    namespace FileToHex
    {
        class Program
        {
            static void Main(string[] args)
            {
                //read only 4 bytes from the file
    
                const int HEADER_SIZE = 4;
    
                byte[] bytesFile = new byte[HEADER_SIZE];
    
                using (FileStream fs = File.OpenRead(@"C:\temp\FileToHex\ex.tiff"))
                {
                    fs.Read(bytesFile, 0, HEADER_SIZE);
                    fs.Close();
                }
    
                string hex = BitConverter.ToString(bytesFile);
    
                string[] header = hex.Split(new Char[] { '-' }).ToArray();
    
                Console.WriteLine(System.String.Join("", header));
    
                Console.ReadLine();
    
            }
        }
    }
