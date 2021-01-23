    public async Task<MyResult> GetAsync()
    {
      // Start several external requests simultaneously.
      Task<Movie> getMovieTask = GetMovieAsync(...);
      Task<Genre> getGenreTask = GetGenreAsync(...);
      ...
      // Asynchronously wait for them all to complete.
      await Task.WhenAll(getMovieTask, getGenreTask, ...);
      var movie = await getMovieTask;
      var genre = await getGenreTask;
      ...
      // Build the result.
      return ...;
    }
