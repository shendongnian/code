        [Authorize(Roles = "Reviewer, User")]
        public ActionResult Index()
        {
            if (Roles.IsUserInRole("Reviewer"))
            {
                return View("ReviewerView");
            }
            else if (Roles.IsUserInRole("User"))
            {
                //Or do a RedirectToAction("SomeAction")
                return View("UserView");
            }
        }
