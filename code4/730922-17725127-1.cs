    public FilterDateRange(string source, int type, string name, DateTime fromDate, DateTime toDate)
    {
        base.Source = source;
        base.Type = type;
        base.Name = name;
        this.FromDate = fromDate; // set FromDate to fromDate (the parameter)
        this.ToDate = toDate;
    }
