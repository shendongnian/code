    static IEnumerable<string> SpaceDelimitedSubstrings(string input)
    {
        List<int> indices = new List<int> { -1 };
        int current = -1;
        while ((current = input.IndexOf(' ', current + 1)) > -1)
        {
            indices.Add(current);
        }
        indices.Add(input.Length);
        int minLength = 1;
        for (int i = 0; i < indices.Count - minLength; i++)
            for (int j = i + minLength; j < indices.Count; j++)
                yield return input.Substring(indices[i] + 1, indices[j] - indices[i] - 1);
    }
