    public static string FormatName(string name)
    {
        const int MaxLength = 20;
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("name");
        if (name.Length <= MaxLength)
            return name;
        string[] tokens = name.Split(' ');
        if (tokens.Length == 0)
            return name; //hyphen the name?
        StringBuilder sb = new StringBuilder(name.Length);
        int len = 0;
        foreach (string token in tokens)
        {
            if (token.Length + len < MaxLength)
            {
                sb.Append(token + " ");
                len += token.Length;
            }
            else
            {
                sb.Append(Environment.NewLine + token + " ");
                len = 0;
            }
        }
        return sb.ToString();
    }
