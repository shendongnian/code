    private ObservableCollection<ComicItem> m_showingComicsListModel;
    public ObservableCollection<ComicItem> ShowingComicsListModel
    {
      get{ return m_showingComicsListModel;}
      set{
           m_showingComicsListModel = value;
           RaisePropertyChanged("ShowingComicsListModel");
      }
    }
