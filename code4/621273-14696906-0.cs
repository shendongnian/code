    public static void logWrongPasswordAttempt(string userName, string passWord)
    {
        // Look for a proxy address first
        var IP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        //Trim and lowercase IP if not null
        if ((IP != null))
        {
            IP = IP.ToLower().Trim();
        }
        if (IP == null || IP.Equals("unknown"))
        {
            //If IP is null use different detection method else pull the correct IP from list.
            IP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToLower().Trim();
        }
        List<string> IPs = null;
        if (IP.IndexOf(",") > -1)
        {
            IPs = IP.Split(new[]{','}, StringSplitOptions.None).ToList();
        }
        else
        {
            IPs = new List<String>() { IP };
        }
        foreach (string ip in IPs)
        {
            // insert your record into database
        }
    }
