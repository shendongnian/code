    public class BasePage : Page
    {
       protected void checkSession()
       {
        if (Session["LoggedIn"] != "true")
        {
            Response.Redirect("default.aspx");
        }
       }
    }
