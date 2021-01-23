    public static string ReauthenticateOn401(
        Func<Authenticator, string> method, 
        ref Authenticator authenticator)
    {
        if (method == null)
            throw new ArgumentNullException("action");
    
        if (authenticator == null)
            throw new ArgumentNullException("authenticator");
    
        int attempts_remaining = 2;
        bool reauth_attempted = false;
        while (attempts_remaining > 0)
        {
            try
            {
                return method(authenticator);
            }
            catch (WebException e)
            {
                if (e.Response != null && reauth_attempted == false)
                {
                    if (((HttpWebResponse)e.Response).StatusCode == HttpStatusCode.Unauthorized)
                    {
                        authenticator.GetAuthToken();
                        reauth_attempted = true;
                        attempts_remaining--;
                    }
                    else
                    {
                        throw;
                    }
                }
                else
                {
                    throw;
                }
            }
        }
        throw new Exception("The ReauthenticateOn401 method failed to return a response or catch/throw an exception.  The log flowed outside the while loop (not expected to be possible) and is generating this generic exception");
            }
