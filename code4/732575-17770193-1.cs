    public class WordsRow : IEqualityComparer<WordsRow>
    {
        public string Row {get; set;}
        public WordsRow() { }
        public WordsRow(string row)
        {
            this.Row = row;                        
        }
        public bool Equals(WordsRow x, WordsRow y)
        {
            return x.Row.Split(' ')[1] == y.Row.Split(' ')[1];
        }
        public int GetHashCode(WordsRow obj)
        {
            return obj.Row.Split(' ')[1].GetHashCode();
        }
    }
