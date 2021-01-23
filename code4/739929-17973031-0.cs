    string text = "blub ASP.filename_aspx foo ASP.filename2_aspx bah ...";
    var matches = new List<string>();
    int index = text.IndexOf("ASP", StringComparison.OrdinalIgnoreCase);
    int endIndex = index >= 0 ? text.IndexOf("_aspx", index + 1, StringComparison.OrdinalIgnoreCase) : -1;
    while (index >= 0 && endIndex >= 0)
    {
        index += "ASP.".Length;
        endIndex += "_aspx".Length;
        matches.Add(text.Substring(index, endIndex - index));
        index = text.IndexOf("ASP", endIndex + 1, StringComparison.OrdinalIgnoreCase);
        endIndex = index >= 0 ? text.IndexOf("_aspx", index + 1, StringComparison.OrdinalIgnoreCase) : -1;
    }
