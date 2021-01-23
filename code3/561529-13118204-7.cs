    public UInt32 UniqueID { get { _UniqueID++; } }
    public void Reset()
    {
        _UniqueID = 0;
    }
