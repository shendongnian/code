    private AuthenticationResult Authenticate(string user, string pwhash)
    {            
        IAuthentication auth = GetIAuthenticator();
        AuthenticationResult result = null;
        AutoResetEvent waitHangle = new AutoResetEvent(false);
    
        auth.AuthenticationDone += (o, e) =>
            {
                result = e;
                waitHangle.Set();
            };
    
        auth.AuthenticateAsync(user, pwhash);
        waitHangle.WaitOne(); // or waitHangle.WaitOne(interval);
        return result;
    }
