    // base
    protected virtual int SomePropertyInternal2
    {
        get
        {
            return 10;
        }
    }
    public int SomeProperty2
    {
        get
        {
            return SomePropertyInternal2;
        }
    // child
    protected override int SomePropertyInternal2
    {
        return 100;
    }
