    [StructLayout(LayoutKind.Explicit)]
    internal struct UInt32Union
    {
        [FieldOffset(0)] public UInt32 Value;
        [FieldOffset(0)] public byte Byte1;
        [FieldOffset(1)] public byte Byte2;
        [FieldOffset(2)] public byte Byte3;
        [FieldOffset(3)] public byte Byte4;
    }
    static UInt32 Swap( UInt32 value )
    {
        UInt32Union src = new UInt32Union
        src.Value = value;
        UInt32Union dest = new UInt32Union
            {
                Byte1 = src.Byte4,
                Byte2 = src.Byte3,
                Byte3 = src.Byte2,
                Byte4 = src.Byte1
            };
        return dest.Value;
    }
