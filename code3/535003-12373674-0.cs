    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Wrapper()
    {
        Throw();
    }
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Throw()
    {
        var x = (string)(object)1;
    }
