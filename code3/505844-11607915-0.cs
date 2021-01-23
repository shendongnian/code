    public byte X
    {
        get { return 0; }
        set { packedValue += (value & 15) << 4; }
    }
    public byte Y
    {
        get { return 0; }
        set { packedValue += value & 15; }
    }
