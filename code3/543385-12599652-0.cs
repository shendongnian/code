    public class ViewModel : NotifyProperyChangedBase
    {       
	string uri;
	
	public ObservableCollection<Movie> MovieList { get; private set; }
    public CollectionView MovieView { get; private set; }
    public ViewModel(MoveList movieList)
    {
		MovieList = movieList;
		MovieView = GetMovieCollectionView(MovieList);
		MovieView.Filter = OnFilterMovie;
    }
    public void UpdateDataGrid(string uri)
    {            
        this.uri = uri;
		MovieView.Refresh();
    }
	
	bool OnFilterMovie(object item)
	{
		var movie = (Movie)item;
		return uri.Contains(movie.ID.ToString());
	}
    public CollectionView GetMovieCollectionView(ObservableCollection<Movie> movList)
    {
        return (CollectionView)CollectionViewSource.GetDefaultView(movList);
    }
}
