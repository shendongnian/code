    using System;
    using System.Runtime.InteropServices;
    
    class BeepSample
    {
        [DllImport("kernel32.dll", SetLastError=true)]
        static extern bool Beep(uint dwFreq, uint dwDuration);
    
        static void Main()
        {
            Console.WriteLine("Testing PC speaker...");
            for (uint i = 100; i <= 20000; i++)
            {
                Beep(i, 5);
            }
            Console.WriteLine("Testing complete.");
        }
    }
