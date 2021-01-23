    static int getCount(DataTable dt, string name)
    {
        return dt.AsEnumerable()
                 .Where(p => p.Field<string>("username") == name)
                 .Select(p => p.Field<int>("count"))
                 .FirstOrDefault();
    }
