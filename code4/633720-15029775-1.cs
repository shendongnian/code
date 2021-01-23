    public static IEnumerable<string> ToTextElements(this string source)
    {
        var e = StringInfo.GetTextElementEnumerator(source)
        while (e.MoveNext())
        {
            yield return e.GetTextElement();
        }
    }
