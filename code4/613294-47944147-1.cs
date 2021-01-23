            List<Movie> AllMovies = new List<Movie>();
            List<MovieDTO> UserFavouriteMovie = new List<MovieDTO>();
            List<MovieDTO> allMovieDTO = AllMovies.Select(x => new MovieDTO
            {
                 MovieName = x.Name
                 , Selected = new Func<bool>(() => {
                     if (UserFavouriteMovie.Exists(a => a.Id == x.Id))
                     {
                         return true;
                     }
                     else
                     {
                         return false;
                     }
                 }).Invoke()
            }).ToList();
