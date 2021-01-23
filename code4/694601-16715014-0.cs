    public static string RemoveNamespaces(string typename)
    {
        return string.Join("", 
              Regex.Split(typename, 
                         @"([^\w\.])").Select(p => 
                                         p.Substring(p.LastIndexOf('.') + 1)));
    }
