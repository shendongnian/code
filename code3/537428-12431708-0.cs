    public static List<string> ConstructCreatePublicationScript(string rawPublicationScript, string rawAddArticleScript)
    {
        .....
    
        List<string> result = new List<string>();
        result.AddRange(createPublicationScript.Split("GO"));
        return result;
    }
