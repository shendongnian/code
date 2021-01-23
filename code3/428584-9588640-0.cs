    public string CustomReplace(string text, string oldValue, string newValue)
    {
        string done = text.Replace(oldValue, newValue);
        var builder = new StringBuilder();
        foreach (var wildcard in Wildcards)
        {
            builder.AppendFormat("({0}|{1})|", Regex.Escape(wildcard.Usage),
                Regex.Escape(wildcard.Escape));
        }
        builder.Length = builder.Length - 1; // Remove the last '|' character
        return Regex.Replace(done, builder.ToString(), WildcardEvaluator);
    }
    private string WildcardEvaluator(Match match)
    {
        var wildcard = Wildcards.Find(w => w.Usage == match.Value);
        if (wildcard != null)
            return wildcard.Value;
        else
            return match.Value;
    }
