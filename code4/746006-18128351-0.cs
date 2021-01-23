    private List<T> GetData<T>(Func<MyEntities, IEnumerable<T>> selector)
    {
        using (MyEntities db = _conn.GetContext())
        {
            return selector(db).ToList();
        }
    }
