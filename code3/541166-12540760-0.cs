    public MovieResponseViewModel FilterMovieResponse(MovieResponse movieResponse)
    {
         return new MovieResponseViewModel 
         {
              Name = moveResponse.Name,
              Id = moveResponse.Id,
              Gross = moveResponse.Gross
         }
    }
