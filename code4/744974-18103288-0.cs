    public static C GetAllInfo<T>(this IQueryable<T> objCust)
    {
        if (typeof(T) == typeof(B))
        {
            return GetAllInfo<B>((IQueryable<B>)objCust);
        }
        if (typeof(T) == typeof(A))
        {
            return GetAllInfo<A>((IQueryable<A>)objCust);
        }
        //fail
    }
