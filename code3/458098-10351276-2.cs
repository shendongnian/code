    namespace ConsoleApplication2
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.IO;
        using System.Threading;
    
        class Program2
        {
            static void Main(string[] args)
            {
                Mutex mutex = null;
                Thread.Sleep(5000);
    
                while (mutex == null)
                {
                    try
                    {
                        mutex = Mutex.OpenExisting("Global\\ConsoleApplication1");
    
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Mutex not found on " + DateTime.Now.ToString());
                        Thread.Sleep(3000);
                    }
    
    
                }
                Console.WriteLine("Application2 executed on " + DateTime.Now.ToString());
                Console.ReadKey();
            }
        }
    }
