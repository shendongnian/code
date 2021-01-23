    public class MovieCollections
    {
        private ICollection<Movie> Movies {get; set;}
        // etc...
    }
    public class Movie
    {
        public string Title {get; private set;}
        public int PlayTime {get; private set;}
        public DateTime ReleaseDate {get; private set;}
    }
