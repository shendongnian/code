    string s = "The quick brown fox jumps over the lazy dog";
    char lastChar = default(char);
    bool addLastChar = false;
    var stringBuilder = new StringBuilder(s);
    for (int i = 0; i < stringBuilder.Length; i++)
    {
        var ch = stringBuilder[i];
        // TODO: consider using char.IsWhiteSpace(ch) method call.
        // Please note: it will return true for different whitespace characters (tabulation, line feed, carriage return, etc).
        if (ch == ' ')
        {
            addLastChar = true;
        }
        else
        {
            if (addLastChar)
            {
                stringBuilder.Insert(i, lastChar);
                addLastChar = false;
            }
            lastChar = ch;
        }
    }
    var result = stringBuilder.ToString();
