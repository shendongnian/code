    private AuthenticationResult Authenticate(string user, string pwhash)
    {            
        IAuthentication auth = GetIAuthenticator();
        AuthenticationResult result = null;
        AutoResetEvent waitHangle = new AutoResetEvent(false);
    
        auth.AuthenticationDone += (o, e) =>
            {
                result = e.Result;
                waitHangle.Set();
            };
    
        auth.AuthenticateAsync(user, pwhash);
        waitHangle.WaitOne();
        return result;
    }
