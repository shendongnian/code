    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace LargeReadWrite
    {
        class Program
        {
            const string fileName = "D:\\PersonalDev\\stackoverflow\\largefile.txt";
            static void Main(string[] args)
            {
                CreateLargeFile();
                ReadLargeFile();
            }
    
            static void CreateLargeFile()
            {
                Random r = new Random();
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    for (uint i = 0; i < 30000000; i++)
                    {
                        sw.WriteLine(r.NextDouble());
                    }
                }
            }
    
            static void ReadLargeFile()
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    double total = 0.0;
                    while (sr.Peek() >= 0)
                    {
                        total += Double.Parse(sr.ReadLine());
                    }
                    Console.WriteLine(total);
                }
            }
        }
    }
