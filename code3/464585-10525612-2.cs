    public string MagicJoin(IEnumerable<Tuple<string,char>> split)
    {
        return split.Aggregate(new StringBuilder(), (sb, tup) => sb.Append(tup.Item1).Append(tup.Item2)).ToString();
    }
    public string MagicJoin(IEnumerable<string> strings, IEnumerable<char> chars)
    {
        return strings.Zip(chars, (s,c) => s + c.ToString()).Aggregate(new StringBuilder(), (sb, s) => sb.Append(s)).ToString();
    }
