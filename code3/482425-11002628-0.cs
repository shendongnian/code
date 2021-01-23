    //.Net 4
    get
    {
        var cleansed = DataFields.Split(new [] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(df => df.Trim())
                                 .Where(str => !string.IsNullOrWhitespace(str));
        return new List<string>(cleansed);
    }
    set
    {
        DataFields = string.Join(",", value);
    }
