    // Returns the contents of text following the target string,
    // or "" if the target string wasn't found.
    public static string ContentAfter(string text, string target)
    {
        int index = text.IndexOf(target);
        if (index >= 0)
            return text.Substring(index + target.Length);
        else
            return "";
    }
        
