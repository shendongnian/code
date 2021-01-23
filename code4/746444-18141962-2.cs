    foreach (var r in results)
    {
        string name, trimmedName = "";
        if (r.GetType() == typeof(ExpandoObject))
        { 
            name = ((IDictionary<string,object>)r).ToList()
                .Aggregate<KeyValuePair<string,object>, string>("", (s, p) =>
            {
                return s + " " + p.Value;
            });
            trimmedName = name.Trim();
        }
        else
        {
            PropertyInfo[] ps = r.GetType().GetProperties();
            name = ps.Aggregate<PropertyInfo, string>("", (s, p) =>
            {
                return s + " " + p.GetValue(r);
            });
            trimmedName = name.Trim();
        }
        // use the trimmedName 
        Console.WriteLine(trimmedName);
    }
