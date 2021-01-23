    public class Genre
    {
        public int Discount { get; set; }
    }
    public class ReadingBooksGenre : Genre { }
    public class TextBooksGenre : Genre { }
    abstract public class Book<T> where T : Genre
    {
        public List<T> Genres { get; set; }
        public int Discount
        {
            get
            {
                return (Genres.Count == 0) ? 0 : Genres.Max(g => g.Discount);
            }
        }
    }
    abstract public class ReadingBook : Book<ReadingBooksGenre> { }
    abstract public class TextBook : Book<TextBooksGenre> { }
