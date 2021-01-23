    public static Task<Movie[]> WhenGetMovies(MyClient client)
    {
        var tcs = new TaskCompletionSource<Movie[]>();
        Action<object, Movie[]> handler = null;
        handler = (obj, args) =>
        {
            tcs.SetResult(args.Result);
            client.GetMoviesCompleted -= handler;
        };
        client.GetMoviesCompleted += handler;
        client.GetMoviesAsync();
        return tcs.Task;
    }
    public static Task<Theater[]> WhenGetMovies(MyClient client)
    {
        var tcs = new TaskCompletionSource<Theater[]>();
        Action<object, Theater[]> handler = null;
        handler = (obj, args) =>
        {
            tcs.SetResult(args.Result);
            client.GetTheatersCompleted -= handler;
        };
        client.GetTheatersCompleted += handler;
        client.GetTheatersAsync();
        return tcs.Task;
    }
