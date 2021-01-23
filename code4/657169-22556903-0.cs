                public class BasePage : Page
                {
                 protected void checkSession()
                   {
                      if (Session["LoggedIn"] == null)
                       {
                               Response.Redirect("~/default.aspx/");
                        }
                   }
                }
