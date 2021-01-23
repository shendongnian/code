    [StructLayout(LayoutKind.Sequential)]
    public struct MyObject
    {
        [MarshalAs(UnmanagedType.I1)]
        public bool ParamOne;
        [MarshalAs(UnmanagedType.I1)]
        public bool ParamTwo;
        [MarshalAs(UnmanagedType.I1)]
        public bool ParamThree;
        [MarshalAs(UnmanagedType.I1)]
        public bool ParamFour;
        [MarshalAs(UnmanagedType.I1)]
        public bool ParamFive;
        [MarshalAs(UnmanagedType.I1)]
        public bool ParamSix;
        [MarshalAs(UnmanagedType.R4)]
        public float ParamSeven;
        [MarshalAs(UnmanagedType.R4)]
        public float ParamEight;
        [MarshalAs(UnmanagedType.R4)]
        public float ParamNine;
        public Vector2f ParamTen;
        public Vector2f ParamEleven;
        public IntPtr ParamTwelve;    // <-- These are your strings
        public IntPtr ParamThirteen;  // <--
        public IntPtr ParamFourteen;  // <--
        public IntPtr ParamFifteen;
        public IntPtr ParamSixteen;
    }
