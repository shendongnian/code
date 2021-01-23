    public void Add<TIn, TOut>(Func<TIn, TOut> func)
    {
        // TODO: Consider using IsAssignableFrom etc
        if (currentOutputType != typeof(TIn))
        {
            throw new InvalidOperationException(...);
        }
        list.Add(o => (object) func((TIn) o));
        currentOutputType = typeof(TOut);
    }
