    private void countWordsInFile(string file, Dictionary<string, int> words)
    {
        var content = File.ReadAllText(file);
        var wordPattern = new Regex(@"\w+");
        foreach (Match match in wordPattern.Matches(content))
        {
            if (!words.ContainsKey(match.Value))
                words.Add(match.Value, 1);
            else
                words[match.Value]++;
        }
    }
