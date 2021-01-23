    public bool IsUnique(int id, params Expression<Func<T, bool>>[] properties)
    {
        var rowCount = _session.QueryOver<T>().CombinedWhere(properties).ToRowCountQuery().RowCount();
        // create
        if (id == 0)
        {
            return rowCount == 0;
        }
        // update
        return rowCount <= 1;
    }
