    private string XmlCharWhiteList(string p)
    {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(char c in p)
            {
                if (c == 0x0009 || c == 0x000A || c == 0x000D ||
                    (c >= 0x0020 && c <= 0xD7FF) ||
                    (c >= 0xE000 && c <= 0xFFFD))
                    stringBuilder.Append(c);
                else
                    stringBuilder.Append(' ');
            }
            return stringBuilder.ToString();
    }
