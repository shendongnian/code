    public MainViewModel(IWindowListener dialogServiceInDisguise)
    {
      WindowListener = dialogServiceInDisguise;
    }
    public IWindowListener WindowListener { get; private set; }
