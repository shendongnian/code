    var prop = item.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
    dynamic i = new ExpandoObject();
    IDictionary<string, object> d = (IDictionary<string, object>)i;
    foreach (var p in prop)
    {
        d.Add(p.Name, p.GetValue(item));
    }
    list.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
