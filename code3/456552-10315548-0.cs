    public string sqlEscape(string VAL)
    {
        if (VAL == null)
        {
            return null;
        }
        return "\"" + Regex.Replace(VAL, @"[\r\n\x00\x1a\\'""]", @"\$0") + "\"";
    }
