    public IList<Title> VmTitles
    {
        get
        {
            return Titles.GetTitles();
        }
    }
    public Title SelectedTitle
    {
        get
        {
            return _selectedTitle;
        }
        set
        {
            if (value != _selectedTitle)
            {
                _selectedTitle = value;
                OnPropertyChanged("SelectedTitle");
            }
        }
    }
