    
    private ICommand _commandField;
    public ICommand CommandProperty
    {
      get
      {
        if (_commandField == null) _commandField = new DelegateCommand(CommandMethod);
        
        return _commandField;
      }
    }
    private void CommandMethod() 
    {
      // do stuff...
    }
