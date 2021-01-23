    public static C GetAllInfo<T>(this IQueryable<T> objCust)
    {
        if (typeof(T) == typeof(B))
        {
            return GetAllInfo((IQueryable<B>)objCust); //call to specialized impl.
        }
        if (typeof(T) == typeof(A))
        {
            return GetAllInfo((IQueryable<A>)objCust); //call to specialized impl.
        }
        //fail
    }
