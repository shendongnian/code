    static void Sort(JObject jObj)
    {
        var props = jObj.Properties().ToList();
        foreach (var prop in props)
        {
            prop.Remove();
        }
        foreach (var prop in props.OrderBy(p => p.Name))
        {
            jObj.Add(prop);
            if (prop.Value is JObject)
                Sort((JObject)prop.Value);
            if (prop.Value is JArray)
            {
                Int32 iCount = prop.Value.Count();
                for (Int32 iIterator = 0; iIterator < iCount; iIterator++)
                    if (prop.Value[iIterator] is JObject)
                        Sort((JObject)prop.Value[iIterator]);
            }
        }
    }
