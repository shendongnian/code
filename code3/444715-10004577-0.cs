    public String ButtonText
    {
        get{ return _ButtonText ?? (_ButtonText = "Add"); }
        set
        { 
            _ButtonText = value;
            NotifyPropertyChanged("ButtonText"); 
    }
    
    
    public ICommand ButtonClickCommand
    {
        get { return _ButtonClickCommand ?? (_ButtonClickCommand = _AddCommand; }
        set
        {
           _ButtonClickCommand= value;
           NotifyPropertyChanged("ButtonClickCommand");
        }
    } 
    private ICommand _AddCommand = new RelayCommand(f => Add())
    private ICommand _SaveCommand = new RelayCommand(f => Save())
    
    private void Add()
    {
        // Add your stuff here
    
        // Now switch the button   
        ButtonText = "Save";
        ButtonClickCommand = SaveCommand;
    }
    
    private void Save()
    {
        // Save your stuff here
    
        // Now switch the button   
        ButtonText = "Add";
        ButtonClickCommand = AddCommand;
    }
