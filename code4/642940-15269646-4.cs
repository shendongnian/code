    List<Movie> MovieData= new List<Movie>();
    Movie m = new Movie();
    m.CreateMovie(5, "d", "s");
    MovieData.Add(m);
    movieListView.ItemsSource = MovieData;
