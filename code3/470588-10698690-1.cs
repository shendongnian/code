    public string LocName(string locID)
    {
        if (locID == null) return string.Empty;
        var name = (from a in idc.Locations
                    where a.ID.ToString().Trim().ToUpper() == locID.ToUpper()
                    select a.Name).FirstOrDefault();
        return name ?? string.Empty;   
    }
