    public class MovieManager
    {
      List<Movie> movies;
      
      public void AddMovie(Movie movie)
      {
        movies.Add(movie);
      }
  
      public Save()
      {
      }
    }
    
    public class Movie
    {
      public string Name;
    }
    
    public class MainForm
    {
      MovieManager manager;
    
      private void NewMovieClick(...)
      {
         using(var form = new MovieForm())
         {
           if(form.ShowDialog(this) == DialogResult.OK)
           {
             manager.Add(from.Movie);
           }
         }
      }
    }
    
    public class MovieForm
    {
      public Movie Movie;
    }
