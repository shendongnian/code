    public class DefaultPageRedirector
    {
        private readonly ICookieService cookieService;
        public DefaultPageRedirector(ICookieService cookieService)
        {
            this.cookieService = cookieService;
        }
        public ActionResult RedirectToDefaultPage(
            Controller controller)
        {
            var page = this.cookieService.GetDefaultPageCookie(
                controller.Request, controller.RouteData);
                
            //Do Something
        }
    }
