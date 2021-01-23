    public ICommand MyCommand { get; private set; }
    
    // ViewModel constructor
    public ViewModel()
    {
        // Instead of object, you can choose the parameter type you want to pass.
        MyCommand = new DelegateCommand<object>(MyCommandHandler);
    }
    public void MyCommandHandler(object parameter)
    {
        // Do stuff with parameter
    }
