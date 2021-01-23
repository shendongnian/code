    23:21:32 : Timer started
    23:21:35 : PC Goes Sleep
    23:22:50 : PC Wakes
    23:22:50 : Timer fired
    23:23:50 : Timer fired
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    
    namespace Test
    {
        class Program
        {
            static System.Timers.Timer timer;
    
            static void Main(string[] args)
            {
                timer = new System.Timers.Timer();
                timer.Interval = 60 * 1000;
                timer.AutoReset = true;
                timer.Elapsed += timer_Elapsed;
                timer.Enabled = true;
    
                Console.WriteLine(String.Format("{0}:{1}:{2} : Timer started", DateTime.Now.ToLocalTime().Hour, DateTime.Now.ToLocalTime().Minute, DateTime.Now.ToLocalTime().Second));
    
                timer.Start();
    
                Thread.Sleep(Timeout.Infinite);
            }
    
            static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                Console.WriteLine(String.Format("{0}:{1}:{2} : Timer fired", DateTime.Now.ToLocalTime().Hour, DateTime.Now.ToLocalTime().Minute, DateTime.Now.ToLocalTime().Second));
            }
        }
    }
