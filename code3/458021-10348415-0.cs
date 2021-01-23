    public static List<T> ToList(DetachedCriteria criteria)
    {
        ISession session = NhSessionHelper.GetCurrentSession();
        List<T> l = criteria.GetExecutableCriteria(session).List<T>();
        return l;
    }
