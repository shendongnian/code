    public int songIndex
    {
        get { return MainPage.songIndex; }
        set
        {
            // set the assigned value to property backing field
            MainPage.songIndex = value;
            // you need to notify with the name of the property as the argument
            OnPropertyChanged("songIndex");
        }
    }
