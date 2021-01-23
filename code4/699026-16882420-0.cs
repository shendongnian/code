    private static SessionDatalist<SessionData> SessionDataList=new SessionDatalist<SessionData>();
    
    public addSessionData()
    {
      lock(SessionDataList)
      {
       
       //add list item here to the SessionDataList
      }
    }
    
    public removeSessionData()
    {
      lock(SessionDataList)
      {
    
         //remove item from SessionDataList
      }
    }
