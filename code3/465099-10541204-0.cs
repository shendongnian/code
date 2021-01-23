    [StructLayout(LayoutKind.Sequential)]
    public struct ComplexStruct
    {
        public Int32 NumSubStruct;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_NO_SUB_STRUCTS)]
        public SubStruct[] arr;
    }
    public static extern UInt32 DLL_Call(IntPtr p);
