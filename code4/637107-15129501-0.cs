    public async Task<Guid> LogIn(string UserName, string Password)
    {
        //Asynchronously get ClientID from DB using UserName and Password
    
        Session NewSession = new Session()
        {
            ClientID = ClientID,
            TimeStamp = DateTime.Now
        };
        DB.Sessions.Add(NewSession);
        await DB.SaveChangesAsync().ConfigureAwait(false);    //NewSession.ID is autopopulated by DB
    
        await CleanSessions(ClientID).ConfigureAwait(false);    //Async method which I want to execute later
    
        return NewSession.ID;
    }
    // simplified: no need for this to be full "async"
    private Task CleanSessions(int ClientID)
    {
        //Asynchronously get expired sessions from DB based on ClientID
        return DB.SaveChangesAsync();
    }
