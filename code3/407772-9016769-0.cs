    using System;
    using System.Diagnostics;
    
    class Program {
        static void Main(string[] args) {
            var process = "devenv";   // Modify this
            var ctr = new PerformanceCounter(".NET CLR Memory", "Gen 2 heap size", process);
            Console.WriteLine(ctr.RawValue);
            Console.ReadLine();
        }
    }
