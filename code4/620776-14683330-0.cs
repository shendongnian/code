    private ICommand _historyCommand;
    public ICommand HistoryCommand
    {
        get { return _historyCommand?? (_historyCommand= new RelayCommand(MyFunction)); }
    }
    private void MyFunction()
    {
         // Function do something.
    }
