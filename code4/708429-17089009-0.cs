    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace ConsoleApplication17088573
    {
        class Program
        {
            static void Main(string[] args)
            {
                for (int i = 0; i < 10; i++)
                {
    
    
                    string fname = "testlog.txt";
    
                    using (var fl = File.Create(fname))
                    {
                        using (var sw = new StreamWriter(fl))
                        {
                            sw.WriteLine("Current datetime is {0}", DateTime.Now);
                        }
                    }
                    var fi = new FileInfo(fname);
                    //Console.WriteLine("Before delete CreationTime: {0}", fi.CreationTime);
                    File.Delete(fname);
                    Console.WriteLine("After delete CreationTime: {0}", fi.CreationTime);
                    Thread.Sleep(1000);
                    
    
                }
    
            }
        }
    }
