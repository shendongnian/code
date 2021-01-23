    private ObservableCollection<LoadMovieData> obsMovies = new ObservableCollection<LoadMovieData>();
    public ObservableCollection<LoadMovieData> ObsMovies
    {
        get { return obsMovies; }
        set { obsMovies = value; RaisePropertyChanged("ObsMovies"); }
    }
