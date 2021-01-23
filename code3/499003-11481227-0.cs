    /// <summary>
    /// Holds the current session for using in threads.
    /// </summary>
    private HttpSessionState CurrentSession;
    
    [WebMethod(EnableSession = true)]
    public void A()
    {
       CurrentSession = Session;
    
       Thread thread = new Thread(B);
       thread.Start();
    }
    
    [WebMethod(EnableSession = true)]
    public void B()
    {
      //for times that method is not called as a thread
      CurrentSession = CurrentSession == null ? Session : CurrentSession;
    
       HttpSessionState session = CurrentSession;
    }
