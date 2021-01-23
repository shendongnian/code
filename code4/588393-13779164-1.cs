    public string[] FindPermutations(string word)
    {
        if (word.Length == 2)
        {
            char[] c = word.ToCharArray();
            string s = new string(new[] { c[1], c[0] });
            return new[]
                {
                    word,
                    s
                };
        }
        List<string> result = new List<string>();
        string[] subsetPermutations = FindPermutations(word.Substring(1));
        char firstChar = word[0];
        foreach (string temp in subsetPermutations
                        .Select(s => firstChar.ToString(CultureInfo.InvariantCulture) + s))
        {
            result.Add(temp);
            char[] chars = temp.ToCharArray();
            for (int i = 0; i < temp.Length - 1; i++)
            {
                char t = chars[i];
                chars[i] = chars[i + 1];
                chars[i + 1] = t;
                string s2 = new string(chars);
                result.Add(s2);
            }
        }
        return result.ToArray();
    }
