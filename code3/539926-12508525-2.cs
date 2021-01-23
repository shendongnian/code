    [ComVisible(true)]
    [Guid("C3E38106-F303-46d9-9EFB-AD8A8CA8644E")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MyStruct
    {
        public int Value;
        // I marshal strings as arrays! see note at the bottom
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string Unit
    }
    [ComVisible(true),
    Guid("BD4E6810-8E8C-460c-B771-E266B6F9122F"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)
    ]
    public interface IMyService
    {
        int GetData([MarshalAs(UnmanagedType.LPArray)] out MyStruct[] data);
    }
