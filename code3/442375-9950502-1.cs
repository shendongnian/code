    public RelayCommand EventTapCommand { get; private set; }
    public MainViewModel()
    {
        EventTapCommand = new RelayCommand(DoSomeCoolStuff);
    }
