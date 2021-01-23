        [ActionName("activate_user")]
        [CaptchaValidator]
        [HttpPost]
        public ActionResult ActivateUser(string email)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(email))
            {
                FormsAuthentication.SetAuthCookie(email, false);
                Repository.ActivateUser(email);     
            }
            return View();
        }
