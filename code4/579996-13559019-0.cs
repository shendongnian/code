    public static void Session_PersistSession(string ticket)
    {
       if (IsolatedStorageSettings.ApplicationSettings.Contains("SessionTicket"))
       {
          IsolatedStorageSettings.ApplicationSettings["SessionTicket"] = ticket;
       }
       else
       {
          IsolatedStorageSettings.ApplicationSettings.Add("SessionTicket", ticket);
       }
    
       IsolatedStorageSettings.ApplicationSettings.Save();
    }
    
    public static string Session_LoadSession()
    {
       string ticket;
       if (IsolatedStorageSettings.ApplicationSettings.TryGetValue<String>("SessionTicket", out ticket))
       {
          return ticket;
       }
    
       return null;
    }
