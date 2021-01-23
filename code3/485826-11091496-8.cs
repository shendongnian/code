    // Generate hexadecimal number in reverse.
    List<char> builder = new List<char>();
    do
    {
        builder.Add(hexChars[num & 15]);
        num >>= 4;
    }
    while (num > 0);
    // Pad with leading 0s for a minimum length of 4 characters.
    while (builder.Count < 4)
        builder.Add('0');
    // Reverse string and get result.
    char[] chars = new char[builder.Count];
    for (int i = 0; i < builder.Count; ++i)
        chars[i] = builder[builder.Count - i - 1];
    string result = new string(chars);
