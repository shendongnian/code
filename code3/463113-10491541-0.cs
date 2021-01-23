    /// <summary>
    /// POST /movies
    /// 
    /// returns HTTP Response => 
    ///     201 Created
    ///     Location: http://localhost/ServiceStack.MovieRest/movies/{newMovieId}
    ///     
    ///     {newMovie DTO in [xml|json|jsv|etc]}
    /// 
    /// </summary>
    public override object OnPost(Movie movie)
    {
        var newMovieId = DbFactory.Exec(dbCmd => {
            dbCmd.Insert(movie);
            return dbCmd.GetLastInsertId();
        });
    
        var newMovie = new MovieResponse {
            Movie = DbFactory.Exec(dbCmd => dbCmd.GetById<Movie>(newMovieId))
        };
    
        return new HttpResult(newMovie) {
            StatusCode = HttpStatusCode.Created,
            Headers = {
                { HttpHeaders.Location, this.RequestContext.AbsoluteUri.WithTrailingSlash() + newMovieId }
            }
        };
    }
