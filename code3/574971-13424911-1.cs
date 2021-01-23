    class Word
    {
        public Word(string str)
        {
            Name = str;
        }
    
        public string Name { get; private set; }
    }
    
    public static void Main(string[] args)
    {
        List<Word> words = new List<Word>();
    
        words.Add(new Word("a"));
        words.Add(new Word("Calculator"));
        words.Add(new Word("aaa"));
        words.Add(new Word("Projects"));
        words.Add(new Word("aa"));
        words.Add(new Word("bb"));
        words.Add(new Word("c"));
    
        IEnumerable<Word> query = words.OrderBy(x => x.Name.ToLower()).ToList();
    
        foreach (Word word in query)
        {
            Console.WriteLine(word.Name);
        }
    }
