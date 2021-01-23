    private ObservableCollection<ListItem> _favoriteItems; 
    public ObservableCollection<ListItem> FavoriteItems 
    { 
        get { return _favoriteItems; }
        private set
        {
            if(value!=favoriteItems)
            {
                    _favoriteItems = value;
                    NotifyPropertyChanged("FavoriteItems");
            }
        } 
    }
