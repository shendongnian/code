    public ObservableCollection <Folder> Folders
        {
        get
           {
           return _Folders;
           }
        set
           {
           _Folders = value;
           OnPropertyChanged("Folders");
           }
       }
