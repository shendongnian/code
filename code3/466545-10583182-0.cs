    foreach (var getter in s.GetType().GetProperties())
    {
        var newData = getter.GetValue(newProject, null);
        var setter = p.GetType().GetProperty(prop.Name)
        setter.SetValue(p, newData, null);
    }
