    private byte x = 0;
    private byte y = 0;
    
    public byte X
    {
        get { return x; }
        set { x = value}
    }
    public byte Y
    {
        get { return y; }
        set { y = value }
    }
 
    private byte packedValue 
    {
        get { return (x & 15 << 4) | (y & 15); }
    }
