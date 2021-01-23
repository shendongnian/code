    public string SubstringWithinUtf8Limit(string text, int byteLimit)
    {
        int byteCount = 0;
        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            if (c < 0x80)
            {
                byteCount++;
            }
            else if (c < 0x800)
            {
                byteCount += 2;
            }
            else
            {
                byteCount += 3;
            }
            if (byteCount > byteLimit)
            {
                // Couldn't add this character. Return its index
                return text.Substring(0, i);
            }
        }
        return text;
    }
