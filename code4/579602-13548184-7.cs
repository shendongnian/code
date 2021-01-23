    public static IEnumerable<string> SplitByCharacterType(string input)
    {
        if (String.IsNullOrEmpty(input))
            throw new ArgumentNullException(nameof(input));
    
        StringBuilder segment = new StringBuilder();
        segment.Append(input[0]);
        var current = Char.GetUnicodeCategory(input[0]);
    
        for (int i = 1; i < input.Length; i++)
        {
            var next = Char.GetUnicodeCategory(input[i]);
            if (next == current)
            {
                segment.Append(input[i]);
            }
            else
            {
                yield return segment.ToString();
                segment.Clear();
                segment.Append(input[i]);
                current = next;
            }
        }
        yield return segment.ToString();
    }
