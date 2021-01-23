    public Dictionary<string, DateTime> Dates
    {
        get
        {
            return from p in this.GetType().GetProperties()
                   where p.PropertyType == typeof(DateTime)
                   select new KeyValuePair<string, DateTime>(p.Name, (DateTime)p.GetValue(this, null));
        }
    }
