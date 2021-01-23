    public ICommand test
    {
        get
        { 
          if(testCommand== null)
          {
             testCommand= new MeCommand(processor);
           }
          return testCommand; 
        }
    }
