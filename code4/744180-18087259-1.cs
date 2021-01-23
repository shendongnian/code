    [StructLayout(LayoutKind.Sequential, Pack=1)]
    struct MyStruct
    {
        public readonly MyEnum Class;
        public readonly int A;
        public readonly int B;
        public readonly int C;
        public readonly int D;
        public MyStruct(MyEnum cls, int a, int b, int c, int d)
        {
            Class = cls;
            A = a;
            B = b;
            C = c;
            D = d;
        }
    }
