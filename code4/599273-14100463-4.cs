    private Size _someSize;
    public ReadOnlySize SomeSize
    {
        get { return new ReadOnlySize(_someSize); }
    }
