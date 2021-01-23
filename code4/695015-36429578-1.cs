    public ICommand OnLoadedCommand { get; private set; }
    
    // Constructor
    public MyUserControlViewModel()
    {
        OnLoadedCommand = new DelegateCommand(OnLoaded);
    }
    
    public void OnLoaded()
    {
      // Ignore any PropertyChanged events that fire 
      // before the UserControl is rendered.  
       IsDirty = false; 
    }
