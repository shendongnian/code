    private byte _myByte;
    public byte LowerHalf
    {
        get
        {
            return (byte)(_myByte & 15);
        }
        set
        {
            _myByte = (byte)(value | UpperHalf * 16);
        }
    }
    public byte UpperHalf
    {
        get
        {
            return (byte)(_myByte / 16);
        }
        set
        {
            _myByte = (byte)(LowerHalf | value * 16);
        }
    }
