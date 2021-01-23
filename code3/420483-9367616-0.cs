    private Regex _assemRegex = new Regex("(?<assembly>^.*?),.*");
    Regex reg = new Regex("(?<type>.*?), PublicKeyToken(=.*?)](?<end>.*)");
    //assume that all replacement types are in the same assembly with TypeReplacer
    static readonly string assembly2Use = System.Reflection.Assembly.GetExecutingAssembly().FullName;
    public override Type BindToType(string assemblyName, string typeName)
    {
        // remove strong name from assembly
        Match match = _assemRegex.Match(assemblyName);
        if (match.Success)
        {
            assemblyName = match.Groups["assembly"].Value;
        }
        // remove strong name from any generic collections as many time as needed
        match = reg.Match(typeName);
        string typeWithoutSN = typeName;
        while (match.Success)
        {
            typeWithoutSN = string.Format("{0}]{1}",
            match.Groups["type"].Value,
            match.Groups["end"].Value);
            match = reg.Match(typeWithoutSN);
        }
        // replace assembly name with the simple assembly
        // name - strip the strong name
        string type = string.Format("{0}, {1}", typeWithoutSN,
        assemblyName);
        // The following line of code returns the type.
        return Type.GetType(type);
    } 
