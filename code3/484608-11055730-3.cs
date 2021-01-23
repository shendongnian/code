    public ICommand CreateStoredProcedure 
    { 
        get 
        { 
            return new RelayCommand<object>(
                (object parameter) => CreateStoredProcedureExecute(parameter), 
                (object parameter) => CanCreateStoredProcedure); 
        } 
    }
    private void CreateStoredProcedureExecute(object parameter)
    {
        string ProcName = parameter as string;
    }
