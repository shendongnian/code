    public static string GetUserIP() {   
        var ip = ( HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null
              && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "" )
             ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
             : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        if (ip.Contains( "," ))
            ip = ip.Split( ',' ).First();
        return ip.Trim();
    }
