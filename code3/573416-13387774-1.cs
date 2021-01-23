    private bool Contains(string source, string given)
    {
        return ExtractValidPhrases(source).Any(p => RegexMatch(p, given));
    }
    private bool RegexMatch(string phrase, string given)
    {
        return Regex.IsMatch(phrase, string.Format(@"\b{0}\b", given), RegexOptions.IgnoreCase);
    }
    private IEnumerable<string> ExtractValidPhrases(string source)
    {
        bool valid = false;
        var parentheses = new Stack<char>();
        var phrase = new StringBuilder();
        for(int i = 0; i < source.Length; i++)
        {
            if (valid) phrase.Append(source[i]);
            switch (source[i])
            {
                case '~':
                    valid = true;
                    break;
                case ' ':
                    if (valid && parentheses.Count == 0)
                    {
                        yield return phrase.ToString();
                        phrase.Clear();
                    }
                    if (parentheses.Count == 0) valid = false;
                    break;
                case '(':
                    if (valid)
                    {
                        parentheses.Push('(');
                    }
                    break;
                case ')':
                    if (valid)
                    {
                        parentheses.Pop();
                    }
                    break;
            }
        }
        if (valid) yield return phrase.ToString();
    }
