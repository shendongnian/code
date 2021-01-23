        public static List<string> GetSentencesFromWords(List<string> words, string fileContents)
        {
            return fileContents.Split('.')
                .Where(s => words.Any(w => s.IndexOf(w) != -1))
                .Select(s => s.TrimStart(' ') + ".")
                .ToList();
        }
