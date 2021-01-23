    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
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
                testUnion();
                Timer.Stop();
    
                Console.WriteLine(Timer.ElapsedTicks);
    
                Timer = new Stopwatch();
    
                Timer.Start();
                testBitConverter();
                Timer.Stop();
    
                Console.WriteLine(Timer.ElapsedTicks);
                Console.ReadKey();
            }
    
            static void testBitConverter()
            {
                byte[] UnionBytes;
    
                for (int i = 0; i < 10000; i++)
                {
                    UnionBytes = BitConverter.GetBytes(i);
                }
            }
    
            static void testUnion()
            {
                byte[] UnionBytes;
    
                for (int i = 0; i < 10000; i++)
                {
                    FooUnion union = new FooUnion() { integer = i };
    
                    UnionBytes = new byte[] { union.byte0, union.byte1, union.byte2, union.byte3 };
    
                }
            }
        }
    }
