    public event EventHandler FileCreated;
    public void CheckFileExists()
    {
      while(!File.Exists(""))
      {
        Thread.Sleep(1000); 
      }
      FileCreated(this, new EventArgs());
    }
