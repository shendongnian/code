    public bool update(Func<T, bool> predicate, T i)
    {
        foreach (var x in KeyRecord.FindAll(item => predicate(JustValue(item))) )
        {
            x.value = i ;
        }
        return true ;
    }
