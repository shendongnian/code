        namespace ConsoleApplication1
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading;
    
        class Program1
        {
            private static  bool isNewMutexCreated = true;
            private static Mutex mutex;
            static void Main(string[] args)
            {
                mutex = new Mutex(true, "Global\\ConsoleApplication1", out isNewMutexCreated);
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
                Console.WriteLine("Application1 executed on " + DateTime.Now.ToString());
    
                Console.ReadKey();
            }
    
            static void CurrentDomain_ProcessExit(Object sender, EventArgs e)
            {
                if (isNewMutexCreated)
                {
                    Console.WriteLine("Mutex Released");
                    mutex.ReleaseMutex();
                }
            }
    
        }
    }
