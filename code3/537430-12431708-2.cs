    public static List<string> ConstructCreatePublicationScript(string rawPublicationScript, string rawAddArticleScript)
    {
        .....
    
        List<string> result = new List<string>();
        result.AddRange(Regex.Split(createPublicationScript, "^GO$", RegexOptions.Multiline));
        return result;
    }
