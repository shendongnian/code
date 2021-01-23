    using System;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.Threading;
    
    class Program {
        static void Main(string[] args) {
            timeBeginPeriod(10);
            while (!Console.KeyAvailable) {
                var sw = Stopwatch.StartNew();
                for (int ix = 0; ix < 100; ++ix) Thread.Sleep(1);
                sw.Stop();
                Console.WriteLine("{0} msec", sw.ElapsedMilliseconds);
            }
            timeEndPeriod(10);
        }
    
        [DllImport("winmm.dll")]
        public static extern uint timeBeginPeriod(int msec);
        [DllImport("winmm.dll")]
        public static extern uint timeEndPeriod(int msec);
    }
