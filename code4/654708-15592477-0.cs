    public class Hymn
    {
        private readonly List<List<string>> _verses = new List<List<string>>();
        public Hymn(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
        public IEnumerable<IEnumerable<string>> Verses { get { return _verses; } }
        public List<string> CreateVerse()
        {
            var verse = new List<string>();
            _verses.Add(verse);
            return verse;
        }
    }
