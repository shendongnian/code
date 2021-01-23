    private ICommand _runTestCommand;
    public ICommand RunTestCommand()
    {
        return _runTestCommand ?? (_runTestCommand = new RelayCommand(RunTest));
    }
