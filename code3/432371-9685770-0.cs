    public sealed class StatResult : IEquatable<StatResult>
    {
        public string Word { get; private set; }
        public UInt64 Views { get; private set; }
        public StatResult(string word, ulong views)
        {
            this.word = word;
            this.views = views;
        }
        public override string ToString()
        {
            return String.Format("{0};{1}", word, views);                
        }
        public override int GetHashCode()
        {
            int hash = 23;
            hash = hash * 31 + Word == null ? 0 : Word.GetHashCode();
            hash = hash * 31 + Views.GetHashCode();
            return hash;
        }
        public override bool Equals(object other)
        {
            return Equals(other as StatResult);
        }
        public bool Equals(StatResult other)
        {
            return other != null &&
                   this.Word == other.Word &&
                   this.Views == other.Views;
        }
    }
