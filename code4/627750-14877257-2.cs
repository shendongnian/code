    var dict = new Dictionary<string, List<string>>();
    foreach (XmlNode node in xnode)
    {
        var key = node.Attributes["key"].Value;
        List<string> values;
        if (!dict.TryGetValue(key, out values))
        {
            values = new List<string>();
            dict.Add(key, values);
        }
        values.Add(node.Attributes["value"].Value);
    }
