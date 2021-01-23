    class QueryFriendlyWordList
    {
        public List<string> Words;
        public QueryFriendlyWordList(Word words)
        {
                Words = new List<string> {words.P1,words.P2, words.P3, words.P4};
        }
    }
