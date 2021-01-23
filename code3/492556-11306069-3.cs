    // This function should reside in your SQL-class.
    public IEnumerable<T> ExecuteObject<T>(string sql)
    {
        List<T> items = new List<T>();
        var data = ExecuteDataTable(sql); // You probably need to build a ExecuteDataTable for your SQL-class.
        foreach(var row in data.Rows)
        {
            T item = (T)Activator.CreateInstance(typeof(T), row);
            items.Add(item);
        }
        return items;
    }
