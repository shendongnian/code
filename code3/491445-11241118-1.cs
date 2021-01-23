        [StructLayout(LayoutKind.Sequential, Pack=1, CharSet = CharSet.Auto)]
    public struct PARENT
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string Name;
        public IntPtr pChild;
        public CHILD Child{
          get {
           return (CHILD)Marshal.PtrToStructure(pChild, typeof(CHILD));
          }
        }
    }
    [StructLayout(LayoutKind.Sequential, Pack=1, CharSet = CharSet.Auto)]
    public struct CHILD
    {
        public UInt32 val1;
        public UInt32 val2;
    }
