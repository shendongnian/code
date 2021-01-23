    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1 {
        class Program {
            static void Main() {
                for (int i = 0; i < 10; i++)
                {
                    Task.Factory.StartNew(Launch).Wait();
                }
            }
            
            static void Launch()
            {
                Console.WriteLine("Launch thread: {0}", 
                                  Thread.CurrentThread.ManagedThreadId);
                Task.Factory.StartNew(Nested).Wait();
            }
            
            static void Nested()
            {
                Console.WriteLine("Nested thread: {0}", 
                                  Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
