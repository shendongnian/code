    public ICommand MyCommand
    {
      get
      {
        return new MvxCommand(async () => await DoMyCommand());
      }
    }
