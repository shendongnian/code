        public LexicalInfo(string text)
        {
            var words = from match in (new Regex(@"\w+")).Matches(text).Cast<Match>() select match.Value;
			wordCount = words.Count();
            uniqueWordCount = words.Distinct().Count();
			Console.WriteLine(words.Distinct().ToArray());
        }
