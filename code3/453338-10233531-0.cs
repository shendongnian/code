    [StructLayout( LayoutKind.Sequential )]
    public struct Effects
    {
        public UInt16 field_1;
        public UInt16 field_2;
        public static Effects FromBytes(byte[] data)
        {
            var value = new Effects();
            value.field_1 = BitConverter.ToUInt16(data, 0);
            value.field_2 = BitConverter.ToUInt16(data, 2);
            return value;
        }
    }
