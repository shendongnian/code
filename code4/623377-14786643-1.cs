        [StructLayout(LayoutKind.Sequential)]
        public struct LabCOLOR
        {
            public ushort L;
            public ushort a;
            public ushort b;
            public ushort pad;
        };
        [DllImport("mscms.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        static extern bool TranslateColors(
            IntPtr hColorTransform,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2), In] RGBColor[] inputColors,
            uint nColors,
            ColorType ctInput,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2), Out] LABColor[] outputColors,
            ColorType ctOutput);
