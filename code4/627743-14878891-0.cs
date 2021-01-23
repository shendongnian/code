    public DelegateCommand MyCommand {get;set;} //INotifyPropertyChanged, etc.
    private void ExecuteMyCommand()
    {
        //Do stuff here.
    }
    public MyViewModel()
    {
        MyCommand = new DelegateCommand(ExecuteMyCommand);
    }
