    public class MovieViewModel
    {
       public ObservableCollection<Movie> MovieData { get; set; }
       
       public MovieViewModel()
       {
          //the code you post
          MovieData = new ObservableCollection<Movie>();
          Movie m = new Movie();
          m.CreateMovie(5, "d", "s");
          MovieData.Add(m);
       }
    }
