    public partial class webservice : System.Web.UI.Page
    {
        [WebMethod]
    	public static string MyCSharpFunction(string c)
    	{
    		return "You typed " + c;
    	}
    
    }
