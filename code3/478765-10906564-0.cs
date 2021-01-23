    var moviesToBuy = from movie in dtMovieListDetails
        orderby movie.Format, movie.Price
        group movie by movie.Format into grp
        select new
        {
            Format = grp.Key,
            Movies = grp.Select (g => new { g.MovieName, g.Price })
        };
