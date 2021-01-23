    static IEnumerable<string> SplitByCharacterType(string input)
    {
        if (String.IsNullOrEmpty(input)) throw new ArgumentNullException("input");
        StringBuilder segment = new StringBuilder();
        segment.Append(input[0]);
        System.Globalization.UnicodeCategory cat = Char.GetUnicodeCategory(input[0]);
        for (int i = 1; i < input.Length; i++)
        {
            var tc = Char.GetUnicodeCategory(input[i]);
            if (tc == cat)
            {
                segment.Append(input[i]);
            }
            else
            {
                yield return segment.ToString();
                segment.Clear();
                segment.Append(input[i]);
                cat = tc;
            }
        }
        yield return segment.ToString();
    }
