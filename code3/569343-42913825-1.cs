    // to be called before HtmlEntity.DeEntitize
    public static string ReplaceProblematicHtmlEntities(string str)
    {
        var sb = new StringBuilder(str);
        //TODO: add other replacements, as needed
        return sb.Replace("&period;", ".")
            .Replace("&abreve;", "ă")
            .Replace("&acirc;", "â")
            .ToString();
    }
