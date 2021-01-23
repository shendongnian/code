    public class BasePage : System.Web.UI.Page
    {
        public UserSession CurrentUserSession
        {
            get
            {
                UserSession userSession = null;
                if (Session["UserSession"] == null)
                {
                    userSession = new UserSession();
                    Session["UserSession"] = userSession;
                }
                else
                    userSession = (UserSession)Session["UserSession"];
                return userSession;
            }
            private set { }
        }
    }
