    public DataSaverFact : IDataSaverFact
    {
        public IDataSaver Create()
        {
          if config setting = "FileSaver" then
            return new FileSaver();
          else
            return new SessionSaver();
        }
    }
