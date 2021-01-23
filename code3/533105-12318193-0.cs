    private static TResult GetJsonData<TRoot, TResult>(
        string jsonRequestURL, Func<TRoot, TResult> resultSelector)
    {
        using (var wc = new WebClient())
        {
            var json = wc.DownloadString(jsonRequestURL);
            var rootObj = JsonConvert.DeserializeObject<TRoot>(json);
            return resultSelector(rootObj);
        }
    }
    private static IEnumerable<MovieDetails> GetMovieDetails(string jsonRequestURL)
    {
        return GetJsonData<MoviesListRootObject, IEnumerable<MovieDetails>>(
            jsonRequestURL,
            rootObj =>
            {
                var responseObject = rootObj.movieResponse;
                var movieDetails = responseObject.Select(
                    movieDetail =>
                        new MovieDetails
                        {
                            Description = movieDetail.description,
                            MovieURI = movieDetail.formats.res150p,
                            Thumbnail = movieDetail.image,
                            Title = movieDetail.title,
                            ID = movieDetail.id
                        });
                return movieDetails;
            });
    }
