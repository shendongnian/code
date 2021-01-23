    public object HandleRegex(string items)
    {        
        Regex r = new Regex(@"[.]");
        var newStr = r.Replace(items, @" ");
        try {
         category = (Category) new EnumConverter(typeof(Category)).ConvertFromString(items.Split(" ",StringSplitOptions.RemoveEmptyEntries)[0]);
            }
        catch {
           throw new ArgumentException("items doesn't contain valid prefix");
        }
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
