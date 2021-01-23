    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void doneFunc(IntPtr thisobj);
    [StructLayout(LayoutKind.Sequential)]
    public struct f_tt
    {
        public uint w;
        public uint h;
        public uint f_cc;
        public uint st;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public IntPtr[] pl;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] strd;
        public doneDelegate done;
        public IntPtr e_cc;
        public uint rsrvd2;
        public uint rsrvd3;
    }
