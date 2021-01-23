    void DoSomething<T>(T param)
    {
        if (param is IEnumerable)
        {
            foreach (var item in (IEnumerable)param)
            {
                // Do something
            }
        }
    }
    void DoSomething<T>(T param)
    {
        if (param is IEnumerable<string>)
        {
            foreach (var item in (IEnumerable<string>)param)
            {
                // Do something
            }
        }
    }
    void DoSomething<T,TItem>(T param)
    {
        if (param is IEnumerable<TItem>)
        {
            foreach (var item in (IEnumerable<TItem>)param)
            {
                // Do something
            }
        }
    }
