    using System;
    using System.Threading;
    
    namespace ThreadPractice
    {
        class Program
        {
            static CountdownEvent CountDown = new CountdownEvent(4);
            static void Main()
            {
                new Thread(() => SaySomething("I am Thread one.")).Start();
                new Thread(() => SaySomething("I am thread two.")).Start();
                new Thread(() => SaySomethingElse("Hello From a different Thread")).Start();
                new Thread(() => SaySomething("I am Thread Three.")).Start();
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("Calling Signal (time #{0})", i);
                    CountDown.Signal();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Done"); 
            }
    
            static void SaySomething(string Something)
            {
                CountDown.Wait();
                Console.WriteLine(Something);
            }
    
            static void SaySomethingElse(string SomethingElse)
            {
                Thread.Sleep(1000);
                Console.WriteLine(SomethingElse);
            }
        }
    }
