    class Movie
    {
      public string FilmName { get; set; }
      public string Genre { get; set; }
    }
...
    var listofGenres = new List<string> { "action", "comedy" };
    
    var Movies = new List<Movie> {new Movie {Genre="action", FilmName="Film1"},
                    new Movie {Genre="comedy", FilmName="Film2"},
                    new Movie {Genre="comedy", FilmName="Film3"},
                    new Movie {Genre="tragedy", FilmName="Film4"}};
    
    var movies = Movies.Join(listofGenres, x => x.Genre, y => y, (x, y) => x).ToList();
