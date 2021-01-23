    public string SubstringWithinUtf8Limit(string text, int byteLimit)
    {
        int byteCount = 0;
        char[] buffer = new char[1];
        for (int i = 0; i < text.Length; i++)
        {
            buffer[0] = text[i];
            byteCount += Encoding.UTF8.GetByteCount(buffer);
            if (byteCount > byteLimit)
            {
                // Couldn't add this character. Return its index
                return text.Substring(0, i);
            }
        }
        return text;
    }
