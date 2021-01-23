    [StructLayout(LayoutKind.Explicit)]
    public struct Convert32BitType
    {
        [FieldOffset(0)]
        public int Int32Value;
        [FieldOffset(0)]
        public float FloatValue;
    }
    
    // Example:
    var tmp = new Convert32BitType();
    tmp.FloatValue = 1.1;
    int ival = tmp.Int32Value;
    byte b1 = (byte)(ival >> 24);
    byte b2 = (byte)(ival >> 16);
    byte b3 = (byte)(ival >> 8);
    byte b4 = (byte)(ival >> 0);
