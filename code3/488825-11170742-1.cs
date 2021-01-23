    public class UserController : Controller
    {
        /// <summary>
        /// user list...
        /// </summary>
        List<User> _users = new List<User> {
            new User{ Id="mhis/001", Name="John Smith"},
            new User{ Id="mhis/002", Name="Some Body Else"}
        };    
        /// <summary>
        /// This is actually a user list, but...
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(_users);
        }
        public ActionResult Details(string idpart1, string idpart2, int? year)
        {
            //do what you have to do with the year...
            ViewBag.year = year;            
            string realUserID = String.Format(@"{0}/{1}", idpart1, idpart2);
            var user = _users.FirstOrDefault(u => u.Id == realUserID);
            return View(user);
        }
    }
