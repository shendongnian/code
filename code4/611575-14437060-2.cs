    using System;
    namespace Demo
    {
        internal class Program
        {
            private static void Main()
            {
                uint value = 0x00ffff00; // 00000000111111111111111100000000
                Console.WriteLine(LeastSigBitSet(value).ToString("x")); // 0x0000100
                Console.WriteLine(MostSigBitSet(value).ToString("x"));  // 0x0800000
            }
            public static uint LeastSigBitSet(uint value)
            {
                return (uint)(value & -value);
            }
            public static uint MostSigBitSet(uint value)
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
