    public string[] getAsArray(JToken token)
    {
        if (token.HasValues)
        {
            return token.Select(m => string(m)).ToArray();
        }
        else
        {
            return ((string)token).Split(",").Select(s => s.Trim()).ToArray();
        }
    }
