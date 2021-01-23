    var id64Generator = new Id64Generator();
    // ...
    public string generateID(string sourceUrl)
    {
        return string.Format("{0}_{1}", sourceUrl, id64Generator.GenerateId());
    }
