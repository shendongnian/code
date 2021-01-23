    public static List<string> GetWordGroups(string text, int limit)
    {
        var words = text.Split(new string[] { " ", "\r\n", "\n" }, StringSplitOptions.None);
        List<string> wordList = new List<string>();
        string line = "";
        foreach (string word in words)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                var newLine = string.Join(" ", line, word).Trim();
                if (newLine.Length >= limit)
                {
                    wordList.Add(line);
                    line = word;
                }
                else
                {
                        line = newLine;
                }
            }
        }
        if (line.Length > 0)
            wordList.Add(line);
        return wordList;
    }
