    [StructLayout(LayoutKind.Explicit)]
    struct MyUnion
    {
        [FieldOffset(0)]
        public bool IsDate;
        [FieldOffset(1)]
        public DateTime dt;
        [FieldOffset(1)]
        public long counter;
    }
