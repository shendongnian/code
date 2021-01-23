    [FacebookAuthorize("email")]
        public async Task<ActionResult> Index(FacebookContext context)
        {
            if (ModelState.IsValid)
            {
                Session["FacebookToken"] = context.AccessToken;
                var user = await context.Client.GetCurrentUserAsync<AppUser>();
                return RedirectToAction("Index", "Account");
            }
            return RedirectToAction("Error", "Home");
        }
        // This action will handle the redirects from FacebookAuthorizeFilter when 
        // the app doesn't have all the required permissions specified in the FacebookAuthorizeAttribute.
        // The path to this action is defined under appSettings (in Web.config) with the key 'Facebook:AuthorizationRedirectPath'.
        public ActionResult Permissions(FacebookRedirectContext context)
        {
            if (ModelState.IsValid)
            {
                return View(context);
            }
            return RedirectToAction("Error", "Home");
        }
        public ActionResult FacebookInit()
        {
            return PartialView();
        }
        public ActionResult Error()
        {
            return View();
        }
