    private byte _myByte;
    public byte LowerHalf
    {
        get
        {
            return _myByte & 15;
        }
        set
        {
            _myByte = value | UpperHalf * 16;
        }
    }
    public byte UpperHalf
    {
        get
        {
            return _myByte / 16;
        }
        set
        {
            _myByte = LowerHalf | value * 16;
        }
    }
