    public YourType()
    {
        this.Seven = new RelayCommand( () => NumberPressed("7"));
        this.Eight = new RelayCommand( () => NumberPressed("8"));
        this.Nine = new RelayCommand( () => NumberPressed("9"));
    }
    public ICommand Nine { get; private set; }
    public ICommand Eight { get; private set; }
    public ICommand Seven { get; private set; }
