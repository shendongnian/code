        using System.Runtime.InteropServices;
        [StructLayout(LayoutKind.Explicit)]
        struct UnionWorker
        {
            [FieldOffset(0)]
            public int i;
            [FieldOffset(0)]
            public float f;
        }
        static int Magnitude(byte b)
        {
            UnionWorker u;
            u.i = 0; // just to please the compiler
            u.f = b;
            return Math.Max((u.i >> 23) & 0xFF, 126) - 126;
        }
