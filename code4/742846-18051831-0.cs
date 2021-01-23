    public object HandleRegex(string items)
    {
        category = items.StartsWith("Part ", StringComparison.CurrentCultureIgnoreCase) ? Category.Part : Category.Escape;
        Regex r = new Regex(@"[.]");
        var newStr = r.Replace(items, @" ");
        switch(category)
        {
            case Category.Part:
                HandlePart(newStr);
                break;
            case Category.Escape:
                HandleEscape(newStr);
                break;
        }
     }
