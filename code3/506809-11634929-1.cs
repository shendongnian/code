    public bool IsFavorite
    {
        get { return ItemController.FavoriteList.Contains( this ); }
    }
    public void Refresh()
    {
        NotifyPropertyChanged("IsFavorite");
    }
