    public static void MapObjectPropertyValues(object e1,
                      object e2,
                      IEnumerable<Type> excludedTypes)
    {
        foreach (var p in e1.GetType().GetProperties())
        {
            if (e2.GetType().GetProperty(p.Name) != null && 
            // next line added
            !(excludedTypes.Contains(p.PropertyType)))
            {
                p.SetValue(e1, e2.GetType().GetProperty(p.Name).GetValue(e2, null), null);
            }
         }
    }
