    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_10
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string usri10_name;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string usri10_comment;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string usri10_usr_comment;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string usri10_full_name;
    }
