    public MyEntitities()
        : base()
    {
        Database.Log = s => System.Diagnostics.Trace.WriteLine(s);
    }
