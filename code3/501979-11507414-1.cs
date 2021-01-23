    private string GetSubstring(string url)
    {
        String client = "";        
        Regex rgx = new Regex(@"\.[a-z-./]+");        
        client = rgx.Replace(attr.url, "");        
        rgx = new Regex("formation-");        
        client = rgx.Replace(client, ""); 
        return client;
    }
