    public async Task LoadData()
    {
        var moviesTask = WhenGetMovies(client);
        var theatersTask = WhenGetTheaters(client);
        var movies = await moviesTask;
        var theaters = await theatersTask;
    }
