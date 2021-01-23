    public string LocName(string locID)
    {
        var name = (from a in idc.Locations
                    where a.ID.ToString().ToUpper() == locID.ToUpper()
                    select a.Name).FirstOrDefault();
        return name;   
    }
