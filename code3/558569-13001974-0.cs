    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public unsafe struct UnionPacket
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        [FieldOffset(0)]
        public fixed byte data[12];
        [FieldOffset(0)]
        public float Time;
        [FieldOffset(4)]
        public Int16 CoordX;
        [FieldOffset(6)]
        public Int16 CoordY;
        [FieldOffset(8)]
        public byte Red;
        [FieldOffset(9)]
        public byte Green;
        [FieldOffset(10)]
        public byte Blue;
        [FieldOffset(11)]
        public byte Alpha;
    }
