    [XmlRoot("movies")]
    public class MovieSummary
    {
        [XmlElement("movie")]
        public List<Movie> Movies { get; set; }
    }
    
    public class Movie
    {
        public int id { get; set; }
        public string name { get; set; }
    }
