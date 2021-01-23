    class Book : IComparable<Book>
    {
        public string title { get; set; }
        public string summary { get; set; }
        public int id { get; set; }
        public int numberofauthors { get; set; }
        public string author { get; set; }
        public int CompareTo(Book other)
        {
            if (other == null) return 1;
            return id.CompareTo(other.id);
        }
    }
