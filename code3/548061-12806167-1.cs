    public MyViewModel(Func<ViewModelBase> viewModelCreator)
    {
        var action = () => { creator = viewModelCreator; SetMainContent(creator()); };
        MyCommand = new RelayCommand(action);
    }
