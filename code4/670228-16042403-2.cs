    private List<LoadMovieData> obsMovies = new List<LoadMovieData>();
    public List<LoadMovieData> ObsMovies
    {
        get { return obsMovies; }
        set { obsMovies = value; RaisePropertyChanged("ObsMovies"); }
    }
