        public List<string> GetMatchedString(string match, string input)
        {
            var sentanceList = input.Split(new char[] { '.', '?', '!' });
            var regex = new Regex(match);
            return sentanceList.Where(sentance => regex.Matches(sentance,0).Count > 0).ToList();
        }
