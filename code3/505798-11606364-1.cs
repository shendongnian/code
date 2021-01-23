    using System;
    using System.Threading;
    
    namespace SO_TimerTroubles
    {
        class Program
        {
            //static Timer t;
            static void Main(string[] args)
            {
                StartTimer();  //Works fine.
                Console.WriteLine("Press Enter to BeginGC");
                Console.ReadLine();
                GC.Collect();  //Timer stops.
                Console.ReadLine();
            }
    
            public static void StartTimer()
            {
                //t =
                new Timer(TimerProc, null, 1000, 1000);
            }
    
            static public void TimerProc(object state)
            {
                Console.WriteLine("Timer Called");
                for (int i = 0; i < 5; i++)
                {
                }
            }
        }
    }
