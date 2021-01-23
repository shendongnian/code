        [HttpPost]
        public ActionResult Login(LoginCredentials user)
        {
            // authenticate
            ...
            if (User.IsInRole("admin"))
            {
                return this.RedirectToAction("Index", "User", new { area = "Admin" });
            }
            return this.RedirectToAction("Index", "User");
        }
        
        This action assumes there's Admin area in your application.
        Custom route constraint
        
