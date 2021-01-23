    Dictionary<string, List<DataRow>> CacheData(DataTable t, params string[] fields)
    {
        Dictionary<string, List<DataRow>> cache = new Dictionary<string, List<DataRow>>();
        StringBuilder key = new StringBuilder();
        foreach (DataRow r in t.Rows)
        {
            key.Clear();
            foreach (string f in fields)
            {
                if (key.Length > 0) { key.Append("_"); }
                key.Append(Convert.ToString(r[f]);
            }
            if (!cache.ContainsKey(key.ToString())) { cache.Add(key.ToString(), new List<DataRow>()); }
            cache[key.ToString()].Add(r);
        }
        return cache;
    }
