    string shortest = list.OrderBy(s => s.Length).First();
    IEnumerable<string> shortestSubstrings = shortest
        .getAllSubstrings()
        .OrderByDescending(s => s.Length);
    var other = list.Where(s => s != shortest).ToArray();
    string longestCommonIntersection = string.Empty;
    foreach (string subStr in shortestSubstrings)
    {
        bool allContains = other.All(s => s.Contains(subStr));
        if (allContains)
        {
            longestCommonIntersection = subStr;
            break;
        }
    }
