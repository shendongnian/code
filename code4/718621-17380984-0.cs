    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    private struct Entity
    {
        public string lpLibFileName;
        public string lpProcName;
        public IntPtr pPointer1;
        public IntPtr pPointer2;
    }
