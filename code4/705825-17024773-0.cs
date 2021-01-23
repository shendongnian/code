    private ICommand _cmdParam;
    public ICommand CmdParam
    {
          get
          {
              if (_cmdParam== null)
                 _cmdParam= new DelegateCommand(DoSomething);
               return _cmdParam;
          }
    }
    private void DoSomething(object obj)
    {
    }
