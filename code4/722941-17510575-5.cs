    using System;
    using System.Runtime.InteropServices;
    namespace Demo
    {
        [StructLayout(LayoutKind.Auto, Pack = 1)]
        public struct TestStruct
        {
            public int    I;
            public double D;
            public short  S;
            public byte   B;
            public long   L;
        }
        class Program
        {
            void run()
            {
                var t = new TestStruct();
                unsafe
                {
                    IntPtr p  = new IntPtr(&t);
                    IntPtr pI = new IntPtr(&t.I);
                    IntPtr pD = new IntPtr(&t.D);
                    IntPtr pS = new IntPtr(&t.S);
                    IntPtr pB = new IntPtr(&t.B);
                    IntPtr pL = new IntPtr(&t.L);
                    Console.WriteLine("I offset = " + ptrDiff(p, pI));
                    Console.WriteLine("D offset = " + ptrDiff(p, pD));
                    Console.WriteLine("S offset = " + ptrDiff(p, pS));
                    Console.WriteLine("B offset = " + ptrDiff(p, pB));
                    Console.WriteLine("L offset = " + ptrDiff(p, pL));
                    Console.WriteLine("Total struct size = " + sizeof(TestStruct));
                }
            }
            long ptrDiff(IntPtr p1, IntPtr p2)
            {
                return p2.ToInt64() - p1.ToInt64();
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
