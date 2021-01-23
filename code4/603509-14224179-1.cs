    namespace TestApplication
    {
        using System;
        internal static class Program
        {
            private static unsafe void Main()
            {           
                var bytes = new Byte[] { 24, 45, 68, 84, 251, 33, 9, 64 };
                fixed (Byte* p = &bytes[0])
                {
                    // Prints pi, too.
                    Console.WriteLine(*((Double*)p));
                }
                Console.ReadLine();
            }
        }
    }
