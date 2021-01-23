    [WebMethod(EnableSession = true)]
    public void A()
    {
       HttpSessionState session = Session;
    
       Action action = () => B_Core(session);
       Thread thread = new Thread(action);
       thread.Start();
    }
    
    [WebMethod(EnableSession = true)]
    public void B()
    {
       HttpSessionState session = Session;
       B_Core(session);
    }
    private void B_Core(HttpSessionState session)
    {
        // todo
    }
