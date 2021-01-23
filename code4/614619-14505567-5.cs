    [StructLayout(LayoutKind.Sequential)]
    public struct CtTagValueItems {
        public int dwLength;
        public ulong nTimestamp;
        public ulong nValueTimestamp;
        public ulong nQualityTimestamp;
        public int bQualityGeneral;
        public int bQualitySubstatus;
        public int bQualityLimit;
        public int bQualityExtendedSubstatus;
        public uint nQualityDatasourceErrorCode;
        public int bOverride;
        public int bControlMode;
    }
    [DllImport("ctapi.dll")]
    static extern int ctTagReadEx(IntPtr hCTAPI, IntPtr tag, IntPtr value, int length, IntPtr tagValueItems);
    public void TestMe() {
        var tagValueItems = new CtTagValueItems();
        var tagValueItemsPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CtTagValueItems)));
        Marshal.StructureToPtr(tagValueItems, tagValueItemsPtr, true);
        var tag = "tag";
        var tagPtr = Marshal.StringToHGlobalAnsi(tag);
        var value = "value";
        var valuePtr = Marshal.StringToHGlobalAnsi(value);
        int length = value.Length;
        var result = ctTagReadEx(IntPtr.Zero, tagPtr, valuePtr, length, tagValueItemsPtr);
        if (result != 15) throw new Exception();
        Marshal.FreeHGlobal(tagValueItemsPtr);
        Marshal.FreeHGlobal(tagPtr);
        Marshal.FreeHGlobal(valuePtr);
    }
