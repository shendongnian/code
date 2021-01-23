    class Entry : IComparable<Entry> {
        public int TimeStamp { get; set; }
        public string Owner { get; set; }
        public Entry(int timeStamp, string owner) {
            this.TimeStamp = timeStamp;
            this.Owner = owner;
        }
        public int CompareTo(Entry other) {
            return this.TimeStamp.CompareTo(other.TimeStamp);
        }
    }
