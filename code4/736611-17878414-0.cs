    String s = "your text here";
    byte[] bytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(s);
    String s2 = Encoding.GetEncoding("ISO-8859-1").GetString(bytes);
    if (String.Equals(s, s2))
    {
        // string s contains only ISO 8859-1 chars
    }
    else
    {
        // string s contains "illegal" chars
    }
