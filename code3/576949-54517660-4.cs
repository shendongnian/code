    [StructLayout(LayoutKind.Explicit)]
    public struct DecimalHelper
    {
        const byte k_SignBit = 1 << 7;
        [FieldOffset(0)]
        public decimal Value;
        [FieldOffset(0)]
        public readonly uint Flags;
        [FieldOffset(0)]
        public readonly ushort Reserved;
        [FieldOffset(2)]
        public byte Scale;
        [FieldOffset(3)]
        byte m_SignByte;
        public int Sign
        {
            get
            {
                return m_SignByte > 0 ? -1 : 1;
            }
        }
        public bool Positive
        {
            get
            {
                return (m_SignByte & k_SignBit) > 0 ;
            }
            set
            {
                m_SignByte = value ? (byte)0 : k_SignBit;
            }
        }
        [FieldOffset(4)]
        public uint Hi;
        [FieldOffset(8)]
        public uint Lo;
        [FieldOffset(12)]
        public uint Mid;
        public DecimalHelper(decimal value) : this()
        {
            Value = value;
        }
        public static implicit operator DecimalHelper(decimal value)
        {
            return new DecimalHelper(value);
        }
        public static implicit operator decimal(DecimalHelper value)
        {
            return value.Value;
        }
    }
