    using System;
    using System.Timers;
    class Program
    {
        public delegate void tm();
    
        static void Main(string[] args)
        {
            var t = new tm(tryMethod);
            var timer = new Timer();
            timer.Interval = 5000;
    
            timer.Start();
    
            timer.Elapsed += (sender, e) => timer_Elapsed(t);
            t.BeginInvoke(null, null);
        }
    
        static void timer_Elapsed(tm p)
        {
            p.EndInvoke(null);
            throw new TimeoutException();
        }
    
        static void tryMethod()
        {
            Console.WriteLine("FooBar");
        }
    }
