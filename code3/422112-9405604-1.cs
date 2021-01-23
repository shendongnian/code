    internal bool RemoteLogin(string password)
    {
        return InvokeMethod(() => Server.RemoteLogin(password));
    }
    internal string GetSessionId()
    {            
        return InvokeMethod( () => Server.GetSessionId());
    }
