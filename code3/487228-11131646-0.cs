    public static IQueryable<int?> GetResult(string b)
    {
        using (PingDbDataContext pingDataContext = new PingDbDataContext())
        {
            pingDataContext.CommandTimeout = 5000;
            pingDataContext.Log = new DebugTextWriter();
            var q = from a in pingDataContext.SomeTable
                    where a.SomeColumn == b
                    select a.id;
            return q;
        }
    }
