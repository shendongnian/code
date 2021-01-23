    public IQueryable<Incident> GetAllOutstandingIncidents()
    {
        return from i in db.Incidents.AsEnumerable()
                   where i.Status != Types.StatusTypes.SignedOff && i.Status != Types.StatusTypes.Complete && i.DeletedDateTime != null
                   orderby i.DueDateTime
                   select i;
    }
