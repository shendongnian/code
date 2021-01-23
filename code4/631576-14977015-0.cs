    public int Compare(Foo x, Foo y)
    {
        // if the names are different, compare by name
        if (!x.Name.Equals(y.Name))
        {
            return x.Name.CompareTo(y.Name);
        }
    
        // if the dates are different, compare by date
        if (!x.Date.Equals(y.Date))
        {
            return x.Date.CompareTo(y.Date);
        }
    
        // finally compare by the counter
        return x.Counter.CompareTo(y.Counter);
    }
