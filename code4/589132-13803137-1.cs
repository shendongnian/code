    ICollectionView view = CollectionViewSource.GetDefaultView(lstMovies.ItemsSource);  
    view.Filter = null;  
    view.Filter = new Predicate<object>(FilterMovieItem);  
    
    
    private bool FilterMovieItem(object obj)  
    {  
        MovieItem item = obj as MovieItem;  
        if (item == null) return false;  
      
        string textFilter = txtFilter.Text;  
      
        if (textFilter.Trim().Length == 0) return true; // the filter is empty - pass all items  
      
        // apply the filter  
        if (item.MovieName.ToLower().Contains(textFilter.ToLower())) return true;  
        return false;  
    }  
