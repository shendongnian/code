    public static void DoAfterGettingResponse(HttpWebResponse resp)
    {
        if (resp != null)
        {
            _authToken = resp.Cookies["auth"].Value;
            _email = email;
            System.Diagnostics.Debug.WriteLine("Connection established! -> " + _authToken);
                
        }
        //Do anything else with the response
    }    
