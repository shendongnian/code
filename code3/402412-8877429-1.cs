    public class Global : System.Web.HttpApplication
	{
        protected void Application_Start(object sender, EventArgs e) 		
		{
            Application["Lock"] = new object();
		}
        //other handlers
    }
    
