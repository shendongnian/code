    private void UpdateUi()
    { 
       //Update your FavoritesList to enable animations.
        OnPropertyChanged("FavoritesList");
    }
    
    private ObservableCollection<FavoriteProgram> _favorites;
    public ObservableCollection<FavoriteProgram> FavoritesList
    {
      get { 
        if (_favorites == null) {
          _favorites = new ObservableCollection<FavoriteProgram>();
        }
      
        return _favorites; 
      }
    }
