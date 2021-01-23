    public static bool EmptyNullChecker(Object o)
    {
        IEnumerable<object> asCollection = o as IEnumerable<object>;
        return o != null && asCollection != null && !asCollection.Any(); 
    }
