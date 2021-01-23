    IEnumerable<string> GetLines(...)
    {
        var list = new List<string>();
        foreach(var col in tab.Columns)
        {
            list.Add(tab.Name.ToString() + "By" + col.Name + ": function(" + col.Name 
                     + ") { /// <param> }");
        }
        return list;
    }
