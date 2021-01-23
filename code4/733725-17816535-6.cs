    struct LexicalInfo
    {
        private int wordCount;
        private int uniqueWordCount;
    
        public LexicalInfo(string text)
        {
            var words = GetWords(text);
            wordCount = Count(words);
            uniqueWordCount = UniqueCount(words);
        }
    
    private string[] GetWords(string text)
    {
        return text.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    }
    
        private int UniqueCount(string[] words)
    {
        var foundWords = new List<string>();
        foreach (var word in words)
        {
            string word = word.ToLower();
            if (!foundWords.Contains(word))
            {
                foundWords.Add(word);
            }
        }
        return foundWords.Length;
    }
    
    private int Count(string[] words)
    {
        return words.Length;
    }
    
        public int WordCount
        {
            get
            {
                return wordCount;
            }
        }
    
        public int UniqueWordCount
        {
            get
            {
                return uniqueWordCount;
            }
        }
    
        public double LexicalDensity
        {
            get
            {
                return ((double)uniqueWordCount / (double)wordCount);
            }
        }
    }
    
    //----
    
    private UpdateLabels(string fbStatus)
    {
        var info = new LexicalInfo(words);
        label_totalwordcount = info.WordCount.ToString();
        label_totaluniquewords.Text = info.UniqueWordCount.ToString();
        label_lexicaldensity = (info.LexicalDensity * 100).ToString() + "%";
    }
