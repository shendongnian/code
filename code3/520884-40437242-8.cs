    using System;
    using sw = System.Diagnostics.Stopwatch;
    class Program
    {
        static void Main()
        {
            int i = 512;
            int[] a = new int[i--];
            while (i > 0) a[i] = i--;
            sw sw = sw.StartNew();
            for ( i = 10000000; i > 0; i--) isSorted(a);
            sw.Stop();
            Console.Write(sw.ElapsedMilliseconds);
            Console.Read();
        }
        static bool isSorted(int[] a)  // OP Cannon
        {
            for (int i = 1; i < a.Length; i++)
                if (a[i - 1] > a[i]) return false;
            return true;
        }
    }
