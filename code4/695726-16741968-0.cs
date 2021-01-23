    public class MovieListViewModel
    {
      public List<MovieModel> Top10ByCreated { get; set; }
      public List<MovieModel> Top10ByRating { get; set; }
    }
    public class MovieModel
    {
      public int Id { get; set; }
      public string Title { get; set; }
      public string Genre { get; set; }
      [Display(Name="Year Released")]
      public DateTime ReleaseDate { get; set; }
      public int CountOfReviews { get; set; }
    }
