    public static IEnumerable<string> TextElements(this string s) {
        var en = System.Globalization.StringInfo.GetTextElementEnumerator(s);
        while (en.MoveNext())
        {
            yield return en.GetTextElement();
        }
    }
