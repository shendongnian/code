    public class AccountController : Controller
    {
        private Context db = new Context();
        public AccountController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        [HttpPost]
        public ActionResult LogOn(LoginTemplate login, string returnUrl)
        {
            User result = db.Users.AsNoTracking()
                .Where(m => m.email == login.email)
                .Where(m => m.password == login.password)
                .SingleOrDefault();
            if (result != null)
            {
                Session["logged"] = true;
                Session["user"] = result;
                return RedirectToAction("Index", "Home");
            }
        }
    }
