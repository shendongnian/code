    foreach (var r in results)
    {
        PropertyInfo[] ps = r.GetType().GetProperties();
        string name = ps.Aggregate<PropertyInfo, string>("", (s, p) =>
        {
            return s + " " + p.GetValue(r);
        });
        var trimmedName = name.Trim();
        // use the trimmedName 
    }
