    // this could be a static method on class A
    public static Expression<Func<A, bool>> BasicSearch(string criteria)
    {
        // this is just an example, of course
        // NHibernate Linq will translate this to something like 
        // 'WHERE a.MyProperty LIKE '%@criteria%'
        return a => criteria.Contains(a.MyProperty); 
    }
