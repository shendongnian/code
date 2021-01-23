    public Tuple<Dictionary<T1, T2>, Dictionary<T1, T2>> GetDictionaries<T1, T2>()
    {
        var dict1 = new Dictionary<T1, T2>();
        var dict2 = new Dictionary<T1, T2>();
        return Tuple.Create(dict1, dict2);
    }
    public void Method()
    {
        var result = GetDictionaries(int, string);
        var dict1 = result.Item1;
        var dict2 = result.Item2;
    }
