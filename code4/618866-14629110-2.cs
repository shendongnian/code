    HashSet<char> vowels = new HashSet<char>(new char[] { 'A', 'E', 'I', 'O', 'U', 'Y' });
    var results = new List<IEnumerable<char>>();
    Predicate<IEnumerable<char>> processGroup = delegate(IEnumerable<char> groupElements)
    {
        int vowelCount = groupElements.Count(x => vowels.Contains(x));
        int consonantCount = groupElements.Count(x => !vowels.Contains(x));
        if (vowelCount < consonantCount && vowelCount > 0)
        {
            results.Add(new List<char>(groupElements));
            return true;
        }
        else
            return false;
    };
    var elements = new char[26];
    for (int i = 0; i < elements.Length; i++)
        elements[i] = (char)('A' + i);
    PermutateElements(elements, processGroup);
