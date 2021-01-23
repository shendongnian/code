    namespace TestApplication
    {
        using System;
        using System.Runtime.InteropServices;
        internal static class Program
        {
            private static unsafe void Main()
            {           
                var x = new ByteDoubleUnion();
                x.bytes[0] =  24;
                x.bytes[1] =  45;
                x.bytes[2] =  68;
                x.bytes[3] =  84;
                x.bytes[4] = 251;
                x.bytes[5] =  33;
                x.bytes[6] =   9;
                x.bytes[7] =  64;
                // Prints pi.
                Console.WriteLine(x.doubleValue);
                Console.ReadLine();
            }
        }
        [StructLayout(LayoutKind.Explicit)]
        internal unsafe struct ByteDoubleUnion
        {
            [FieldOffset(0)]
            internal Double doubleValue;
            [FieldOffset(0)]
            internal fixed Byte bytes[8];
        }
    }
