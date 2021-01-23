            [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;
                ViewBag.DisplayMenu = UserRole();
                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged in";
            }
            return View();
        }
        public string UserRole()
        {
            string urole = "non";
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                urole = String.Join(",", s.ToArray());
            }
            return urole;
        }
