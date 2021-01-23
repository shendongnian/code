    public static string GetIPAddress()
    {
    	System.Web.HttpContext context = System.Web.HttpContext.Current;
    	string sIPAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
    	if (string.IsNullOrEmpty(sIPAddress)) {
    		return context.Request.ServerVariables["REMOTE_ADDR"];
    	} else {
    		string[] ipArray = sIPAddress.Split(new Char[] { ',' });
    		return ipArray[0];
    	}
    }
