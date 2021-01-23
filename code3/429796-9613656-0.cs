        bool HasValidCharacters(string word)
        {
            var allowedCharacters = new List<string> { "a", "b", "c" };
            return string.Join("", word.GroupBy(c => c)
                                       .Select(g => g.Key)
                                       .OrderBy(g => g))
                         .Equals(string.Join("", allowedCharacters.OrderBy(c => c)));
        }
