    [StructLayout(LayoutKind.Explicit)]
    public struct DoubleLongUnion
    {
        [FieldOffset(0)]
        public double Double;
        [FieldOffset(0)]
        public long Long;
    }
    public static long DoubleToInt64Bits(double value)
    {
        var union = new DoubleLongUnion {Double = value};
        return union.Long;
    }
