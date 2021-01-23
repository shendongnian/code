    public string ShortestRepeating(string str)
    {
        for(int len = 1; len <= str.Length; len++)
        {
            if (str.Length % len == 0)
            {
                sub = str.SubString(0, len);
                StringBuilder builder = new StringBuilder(str.Length)
                while(builder.Length < str.Length)
                    builder.Append(sub);
                if(str == builder.ToString())
                    return sub;
            }
        }
        return str;
    }
