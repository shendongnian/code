The dictionary keys must be unique, and this is not specific to Lucene but instead to the .NET Dictionary&lt;TKey, TValue&gt; class. One possible option is to pipe delimit the values under one "Category" dictionary key, and then split on the pipe character to parse them out:
    RowData = new Dictionary<string, string>()
    {
        {"Name", a.Name},
        {"Url", a.NiceUrl},
        {"Category", "1234|5678"}
    }
You could then use string.Split on the pipe character '|' to parse them back out.
