    [StructLayout(LayoutKind.Sequential)]
    struct RECT
    {
        public int left, top, right, bottom;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct IMAGEINFO
    {
        public IntPtr hbmImage;
        public IntPtr hbmMask;
        public int Unused1;
        public int Unused2;
        public RECT rcImage;
    }
    [DllImport("Comctl32.dll", SetLastError = true)]
    static extern bool ImageList_GetImageInfo(IntPtr himl, int i,
        ref IMAGEINFO pImageInfo);
