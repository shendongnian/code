    using System;
    using System.Threading;
    
    namespace ConsoleApplication6
    {
        class Program
        {
    
            public void TimerTask(object state)
            {
                //Do your task
                Console.WriteLine("oops");
            }
    
            static void Main(string[] args)
            {
                var program = new Program();
                var timer = new Timer(program.TimerTask, 
                                      null, 
                                      3000, 
                                      Timeout.Infinite);
                Thread.Sleep(10000);
            }
        }
    }
