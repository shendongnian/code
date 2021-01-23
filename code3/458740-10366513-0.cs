    public class BaseController : Controller
    {
        public User User { get; private set; }
        public BaseController()
        {
            this.User = Session["_User"] as User;
        }
    }
