    foreach (string type in typelist)
    {
        string typeCaptured = type;
        IEnumerable<string> lst = 
            from row in root.Descendants()
            where row.Attribute("serial").Value.Substring(0, 3).Equals(typeCaptured)
            select row.Attribute("serial").Value.Substring(3).ToLower();
        serialLists.Add(typeCaptured, lst);
    }
