    public ICommand MyCommand
    {
      get
      {
        return new MvxAsyncCommand(DoMyCommand);
      }
    }
