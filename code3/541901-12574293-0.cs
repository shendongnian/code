    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Name
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string FirstName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string LastName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public string[] Array;
    };
