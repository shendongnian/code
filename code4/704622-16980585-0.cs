    public static class SessionTest
    {
    	public static string OutputSession()
    	{
    		return System.Web.HttpContext.Current.Session.SessionID.ToString();
    	}
    }
