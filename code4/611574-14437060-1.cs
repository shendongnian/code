    // Implementation of Least|Most SigBitSet from http://aggregate.org/MAGIC/
    using System;
    namespace Demo
    {
        internal class Program
        {
            private static void Main()
            {
                int value = 0x0ff0; // 0000111111110000
                Console.WriteLine(LeastSigBitSet(value).ToString("x")); // 0x0010
                Console.WriteLine(MostSigBitSet(value).ToString("x"));  // 0x0800
            }
            public static int LeastSigBitSet(int value)
            {
                return value & -value;
            }
            public static int MostSigBitSet(int value)
            {
                value |= (value >> 1);
                value |= (value >> 2);
                value |= (value >> 4);
                value |= (value >> 8);
                value |= (value >> 16);
                return (value & ~(value >> 1));
            }
        }
    }
