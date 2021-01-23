    public IEnumerable<StateEnum> GetStates()
    {
        VettingDataContext dc = new VettingDataContext(_connString);
        dc.DeferredLoadingEnabled = true;
        var query = (from c in dc.ZipCompares select c.State ).Distinct();
        return query;
    }
