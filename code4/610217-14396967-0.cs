    static string ReplaceSingleMatch(Match m)
    {
        int length;
        if (!int.TryParse(m.Groups[4].Value, out length))
            length = 1;
        char[] chars = new char[length];
        for (int i = 0; i < chars.Length; i++)
            chars[i] = RandomDigit()[0];
        return new string(chars);
    }
