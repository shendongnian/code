    public static string ReplaceGroups(Match match, Dictionary<int, string> groupValues)
    {
        StringBuilder result = new StringBuilder();
        int currentIndex = 0;
        int offset = 0;
        foreach (KeyValuePair<int, string> replaceGroup in groupValues.OrderBy(x => x.Key))
        {
            Group group = match.Groups[replaceGroup.Key];
            if (currentIndex < group.Index)
            {
                result.Append(match.Value.Substring(currentIndex, group.Index - match.Index - currentIndex));
            }
            result.Append(replaceGroup.Value);
            offset += replaceGroup.Value.Length - group.Length;
            currentIndex = group.Index - match.Index + group.Length;
        }
        return result.ToString();
    }
