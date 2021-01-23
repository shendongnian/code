    // the declarations
    public struct FIXED
    {
        public short fract;
        public short value;
    }
    
    public struct MAT2
    {
        [MarshalAs(UnmanagedType.Struct)] public FIXED eM11;
        [MarshalAs(UnmanagedType.Struct)] public FIXED eM12;
        [MarshalAs(UnmanagedType.Struct)] public FIXED eM21;
        [MarshalAs(UnmanagedType.Struct)] public FIXED eM22;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct POINTFX
    {
        [MarshalAs(UnmanagedType.Struct)] public FIXED x;
        [MarshalAs(UnmanagedType.Struct)] public FIXED y;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct GLYPHMETRICS
    {
    
        public int gmBlackBoxX;
        public int gmBlackBoxY;
        [MarshalAs(UnmanagedType.Struct)] public POINT gmptGlyphOrigin;
        [MarshalAs(UnmanagedType.Struct)] public POINTFX gmptfxGlyphOrigin;
        public short gmCellIncX;
        public short gmCellIncY;
    
    }
    private const int GGO_METRICS = 0;
    
    [DllImport("gdi32.dll")]
    static extern uint GetGlyphOutline(IntPtr hdc, uint uChar, uint uFormat,
       out GLYPHMETRICS lpgm, uint cbBuffer, IntPtr lpvBuffer, ref MAT2 lpmat2);
    
    [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true, SetLastError = true)]
    static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
