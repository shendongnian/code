    public void Register<TParameters, TResult>
            (Func<IQuery<TParameters, TResult>> factory)
        where TParameters : class
        where TResult : class
    {
    }
    public IQuery<TParameters, TResult> Create<TParameters, TResult>()
        where TParameters : class
        where TResult : class
    {
    }
