    string first = list.First();
    var other = list.Skip(1);
    string longestCommonIntersection = string.Empty;
    for (int i = 0; i < first.Length; i++)
    { 
        string currentSubstring = first.Substring(i);
        bool allContains = other.All(s => s.Contains(currentSubstring));
        if (allContains)
        {
            longestCommonIntersection = currentSubstring;
            break;
        }
    }
