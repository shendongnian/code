    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    namespace SplitIntIntoBytes
    {
        [StructLayout(LayoutKind.Explicit)]
        struct FooUnion
        {
            [FieldOffset(0)]
            public byte byte0;
            [FieldOffset(1)]
            public byte byte1;
            [FieldOffset(2)]
            public byte byte2;
            [FieldOffset(3)]
            public byte byte3;
    
            [FieldOffset(0)]
            public int integer;
        }
        class Program
        {
            static void Main(string[] args)
            {
                testUnion();
                testBitConverter();
    
                Stopwatch Timer = new Stopwatch();
    
                Timer.Start();
                int sumTestUnion = testUnion();
                Timer.Stop();
    
                Console.WriteLine("time of Union:        " + Timer.ElapsedTicks + " milliseconds,  sum: " + sumTestUnion);
    
                Timer.Restart();
                int sumBitConverter = testBitConverter();
                Timer.Stop();
    
                Console.WriteLine("time of BitConverter: " + Timer.ElapsedTicks + " milliseconds,  sum: " + sumBitConverter);
                Console.ReadKey();
            }
    
            static int testBitConverter()
            {
                byte[] UnionBytes = new byte[4];
                byte[] SumOfBytes = new byte[4];
                SumOfBytes[0] = SumOfBytes[1] = SumOfBytes[2] = SumOfBytes[3] = 0;
    
                for (int i = 0; i < 10000; i++)
                {
                    UnionBytes = BitConverter.GetBytes(i);
                    SumOfBytes[0] += UnionBytes[0];
                    SumOfBytes[1] += UnionBytes[1];
                    SumOfBytes[2] += UnionBytes[2];
                    SumOfBytes[3] += UnionBytes[3];
                }
                return SumOfBytes[0] + SumOfBytes[1] + SumOfBytes[2] + SumOfBytes[3];
            }
    
            static int testUnion()
            {
                byte[] UnionBytes;
                byte[] SumOfBytes = new byte[4];
                SumOfBytes[0] = SumOfBytes[1] = SumOfBytes[2] = SumOfBytes[3] = 0;
    
                FooUnion union = new FooUnion();
    
                for (int i = 0; i < 10000; i++)
                {
                    union.integer = i;
                    UnionBytes = new byte[] { union.byte0, union.byte1, union.byte2, union.byte3 };
                    SumOfBytes[0] += UnionBytes[0];
                    SumOfBytes[1] += UnionBytes[1];
                    SumOfBytes[2] += UnionBytes[2];
                    SumOfBytes[3] += UnionBytes[3];
                }
                return SumOfBytes[0] + SumOfBytes[1] + SumOfBytes[2] + SumOfBytes[3];
            }
        }
    }
