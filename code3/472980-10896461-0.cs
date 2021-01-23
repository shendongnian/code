    XElement root = XElement.Load(file);
    string[] cats = root.XGet("//category/name", string.Empty).Distinct().ToArray();
    Dictionary<string, string[]> dict = new Dictionary<string, string[]>();
    foreach (string cat in cats)
    {
        // Get all the categories by name and their subcat names
        string[] subs = root
            .XGet("//category[name={0}]/subcategories/subcat/name", string.Empty, cat)
            .Distinct().ToArray();
        dict.Add(cat, subs);
    }
