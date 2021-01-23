    public void LoadData()
    {
        // Get data always from a fresh context on reload,
        // to have most recent data from the database
        using (var context = new TraceContext())
        {
            LoadData(context);
        }
    }
    public void LoadData(TraceContext context)
    {
        Measurements = context.Measurements.ToList();
    }
