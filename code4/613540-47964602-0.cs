    private ICommand _testRunCommand = null;
    public ICommand TestrunStartCommand
    {
        get 
        { 
            return _testRunCommand ?? (_testRunCommand = new RelayCommand(TestrunStartExecute, () => !IsTestrunInProgress)); 
        }
    }
