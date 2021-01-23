    public class BaseController : Controller
    {
          public User CurrentUser
            {
                get
                {
                    if (HttpContext.User == null || HttpContext.User.Identity.AuthenticationType != "Forms")
                        return null;
                    if (Session["CurrentUser"] != null)
                        return (User)Session["CurrentUser"];
                    var identity = HttpContext.User.Identity;
                    var ticket = ((FormsIdentity)identity).Ticket;
                    int userId;
                    if (!int.TryParse(ticket.UserData, out userId)
                        return null;
    
                    using (var db= new DbEntities(connectionString))
                    {
                        Session["CurrentUser"] = db.Users.SingleOrDefault(u => u.ID == userId));
                    }
    
                    return (User)Session["CurrentUser"];
                }
                
    	    set { Session["CurrentUser"] = value; }
            }
    }
