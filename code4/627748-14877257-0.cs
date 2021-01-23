    var dict = new Dictionary<string, List<string>>();
    for (int iCount = 0; iCount < xnode.Count; iCount++)
    {
        var key = xnode[iCount].Attributes["key"].Value.ToString();
        List<string> values;
        if (!dict.TryGetValue(key, out values))
        {
            values = new List<string>();
            dict.Add(key, values);
        }
        values.Add(xnode[iCount].Attributes["value"].Value.ToString());
    }
