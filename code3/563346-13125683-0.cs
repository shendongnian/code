    using System;
    using System.Timers;
    
    class Program {
        static void Main(string[] args) {
            var t = Timer();
            t.Elapsed += ElapsedEventHandler((s, e) => { });
            t.Start();
        }
    }
