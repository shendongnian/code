    private MySize _someSize;
    protected MySize SomeSize
    {
        get { return _someSize.GetCopy(); }
        private set { _someSize = value; }
    }
