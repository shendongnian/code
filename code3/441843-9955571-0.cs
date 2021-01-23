        private void countWordsInFile(string file, Dictionary<string, int> words)
        {
            var content = File.ReadAllText(file);
            var wordPattern = new Regex(@"\w+");
            foreach (Match match in wordPattern.Matches(content))
            {
                int currentCount=0;
                words.TryGetValue(match.Value, out currentCount);
                currentCount++;
                words[match.Value] = currentCount;
            }
        }
