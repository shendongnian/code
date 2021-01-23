    public class NavigationController : Controller
    {
        [ChildActionOnly]
        public PartialViewResult GetMenuForUser()
        {
            var model = _securityLayer.GetUrlForUser(HttpContext.User.Identity.Name);
            return PartialView("_UserMenu", model);
        }
    }
