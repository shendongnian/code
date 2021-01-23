    // Look for a proxy address first
    var IP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
    //Trim and lowercase IP if not null
    if (IP != null)
    {
        IP = IP.ToLower().Trim();
    }
    if (IP == null || IP.Equals("unknown"))
    {
        //If IP is null use different detection method else pull the correct IP from list.
        IP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToLower().Trim();
    }
    String[] IPs = null;
    if (IP.IndexOf(",") > -1)
    {
        IPs = IP.Split(',');
    }
    else
    {
        IPs = new string[] { IP };
    }
