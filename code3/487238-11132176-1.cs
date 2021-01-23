    var d = list
        .GroupBy(x=>x.CountryID)
        .ToDictionary(g=> g.Key.ToString(), 
            g => g.ToDictionary(x => x.StateID.ToString(),x => x.StateName));
    var serializer = new JavaScriptSerializer();
    return serializer.Serialize(d);
