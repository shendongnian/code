    public class Movie
    {
      [XmlElement("MovieName")]
      public string Title
      { get; set; }
    
      [XmlElement("MovieRating")]
      public float Rating
      { get; set; }
    
      [XmlElement("MovieReleaseDate")]
      public DateTime ReleaseDate
      { get; set; }
    }
