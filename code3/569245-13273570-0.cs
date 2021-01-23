    public string sanitizeJavascriptString(string dirtyInput)
    {
        return dirtyInput.Replace("\\", "\\\\")
            .Replace("\"", "\\\"")
            .Replace("'","\\'");
    }
