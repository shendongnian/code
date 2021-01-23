    public class AccountController : Controller
    {
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Site");
            }
            return View("Login", new LogOnModel());
        }
	}
