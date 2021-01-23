    public class Book
    {
      public string Author { get; set; }
      public Genre Genre { get; set; }
    
      public Book(string author, Genre genre)
      {
        Author = author;
        Genre = genre;
      }
    }
    
    public class Genre 
    {
      public string Name { get; set; }
    
      public static ICollection<Genre> List = new List<Genre>();
    
      public Genre(string name)
      {
        Name = name;
    
        List.Add(this);
      }
    }
