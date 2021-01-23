    [StructLayout(LayoutKind.Explicit)]
    struct StructTest
    {
        // A byte at the beginning of the struct.
        [FieldOffset(0)]
        public byte byte1;
        // Another byte immediately after it.
        [FieldOffset(1)]
        public byte byte2;
        // Now an integer which covers both.
        [FieldOffset(0)]
        public Int16 int1;
    }
