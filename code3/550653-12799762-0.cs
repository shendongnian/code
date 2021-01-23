    public void LaunchProcessAsynchrousCall(string paramStr) 
    {
          ThreadStart displayContentHandler = delegate()
          {
               LaunchProcess(paramStr)
           };
    
           Thread thread = new Thread(displayContentHandler);
           thread.IsBackground = true;
           thread.Start();
     }
