    IEnumerable<string> firstSubstrings = list.First().getAllSubstrings()
        .OrderByDescending(s => s.Length);
    var other = list.Skip(1);
    string longestCommonIntersection = string.Empty;
    foreach (string subStr in firstSubstrings)
    {
        bool allContains = other.All(s => s.Contains(subStr));
        if (allContains)
        {
            longestCommonIntersection = subStr;
            break;
        }
    }
