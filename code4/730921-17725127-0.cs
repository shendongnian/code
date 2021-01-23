    public FilterDateRange(string source, int type, string name, DateTime fromDate, DateTime toDate)
    {
        base.Source = source;
        base.Type = type;
        base.Name = name;
        this.FromDate = FromDate; // set FromDate to FromDate (the property) 
        this.ToDate = ToDate;
    }
