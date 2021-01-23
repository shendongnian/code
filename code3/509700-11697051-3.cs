    public static MovieDetails operator as(FacebookMovie m)
    {
       if (m == null) return null;
    
        MovieDetails objMovieDetails = new MovieDetails()
            {
              ID = 0,
              Source = Movies.Source,
              SourceID = Convert.ToString(Movies.ID),
              Title = Movies.Name,
              URL = GetInternalMovieURL(objMovieDetails.Source, objMovieDetails.SourceID),
              ImageURL = Movies.Picture,
              SourceURL = Movies.SourceURL,
              Description = Movies.Description
           }
    
        return objMovieDetails
    }
