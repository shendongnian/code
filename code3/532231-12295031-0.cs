    using System;
    using System.Diagnostics;
    public sealed class IntObj
    {
        public readonly int Value;
        public IntObj(int value)
        {
            Value = value;
        }
    }
    static class Program
    {
        static void Main()
        {
            Run(1, 0, false);
            Run(100000, 500, true);
            Console.ReadKey();
        }
        static void Run(int length, int repeat, bool report)
        {
            var data = new object[length];
    
            int chk = 0;
            var watch = Stopwatch.StartNew();
            for (int j = 0; j < repeat; j++)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = i;
                    chk += i;
                }
            }
            watch.Stop();
            if(report) Console.WriteLine("Box: {0}ms (chk: {1})", watch.ElapsedMilliseconds, chk);
            chk = 0;
            watch = Stopwatch.StartNew();
            for (int j = 0; j < repeat; j++)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    chk += (int) data[i];
                }
            }
            watch.Stop();
            if (report) Console.WriteLine("Unbox: {0}ms (chk: {1})", watch.ElapsedMilliseconds, chk);
    
            chk = 0;
            watch = Stopwatch.StartNew();
            for (int j = 0; j < repeat; j++)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = new IntObj(i);
                    chk += i;
                }
            }
            watch.Stop();
            if (report) Console.WriteLine("Wrap: {0}ms (chk: {1})", watch.ElapsedMilliseconds, chk);
            chk = 0;
            watch = Stopwatch.StartNew();
            for (int j = 0; j < repeat; j++)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    chk += ((IntObj)data[i]).Value;
                }
            }
            watch.Stop();
            if (report) Console.WriteLine("Unwrap: {0}ms (chk: {1})", watch.ElapsedMilliseconds, chk);
        }
        
    
    }
