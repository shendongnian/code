    // assume x is the low nibble
    public byte X
    {
        get { return (byte)(packedValue & 15); }
        set { packedValue = (packedValue & 240) | (value & 15); }
    }
    // assume y is the high nibble
    public byte Y
    {
        get { return (byte) (packedValue >> 4); }
        set { packedValue = (value << 4) | (packedValue & 15); }
    }
