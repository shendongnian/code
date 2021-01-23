    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe struct complex_struct {
        public int d;
        public int e;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public simple_struct[] f;
        public short g;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public simple_struct[] h;
        public short i;
    } ;
