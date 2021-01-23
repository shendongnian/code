    string str = "ĄĆŹ - ćwrą";
    public string ToJsonString(string s)
    {
        var enumerator = StringInfo.GetTextElementEnumerator(s);
        var sb = new StringBuilder();
        while (enumerator.MoveNext())
        {
            var unicodeChar = enumerator.GetTextElement();
            var codePoint = char.ConvertToUtf32(unicodeChar, 0);
            if (codePoint < 0x80) {
                sb.Append(unicodeChar);
            }
            else if (codePoint < 0xffff) {
                sb.Append("\\u").Append(codePoint.ToString("x4"));
            }
            else {
                sb.Append("\\u").Append((codePoint & 0xffff).ToString("x4"));
                sb.Append("\\u").Append(((codePoint >> 16) & 0xffff).ToString("x4"));
            }
        }
        return sb.ToString();
    }
