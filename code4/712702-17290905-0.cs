     [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct AccessibleTable
    {
        [MarshalAs(UnmanagedType.I4)]
        public int index;
        [MarshalAs(UnmanagedType.I4)]
        public int row;
        [MarshalAs(UnmanagedType.I4)]
        public int column;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct AccessibleTableInfo
    {
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst=2)]
        public string caption;
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst=2)]
        public string summary;
        [MarshalAs(UnmanagedType.I4)]
        public int rowCount;
        [MarshalAs(UnmanagedType.I4)]
        public int columnCount;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPStruct)]
        public AccessibleContextInfo[] accessibleContext;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPStruct)]
        public AccessibleTable[] accessibleTable;
    }
