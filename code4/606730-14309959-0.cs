    [Flags]
    public enum UIntEnum : byte
    {
        None = 0x0,
        One = 0x1,
        Two = 0x2,
        Three = 0x4,
        Four = 0x8,
        Five = 0x10,
        Six = 0x20
    };
    
    public static class UIntEnumExtensions
    {
        public static Boolean ContainsOne(this UIntEnum enum)
        {
            return ((enum & UIntEnum.One) == UIntEnum.One);
        }
        public static Boolean ContainsTwo(this UIntEnum enum)
        {
            return ((enum & UIntEnum.Two) == UIntEnum.Two);
        }
        // And so on...
        public static List<UInt32> GetComponents(this UIntEnum enum)
        {
            List<UInt32> values = new List<UInt32>();
            if (enum.ContainsOne())
                values.Add((UInt32)1);
            if (enum.ContainsTwo())
                values.Add((UInt32)2);
            // And so on...
        }
    }
