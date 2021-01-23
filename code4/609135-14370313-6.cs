    private byte[] _theRawImageBytes;
    public byte[] TheRawImageBytes
    {
        get { return _theRawImageBytes; }
        set { _theRawImageBytes = value; RaisePropertyChanged(() => TheRawImageBytes); }
    }
