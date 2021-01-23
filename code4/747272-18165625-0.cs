       [AllowAnonymous]
        public ActionResult ForgotMyPassword(string confirmation, string username)
        {
            username = HttpUtility.UrlDecode(username);
            ViewBag.Succeed = false;
            SetPasswordViewModel Fmp = new SetPasswordViewModel(username,confirmation);
            return View(Fmp);
        }
        //
        // POST: /Account/ForgotMyPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotMyPassword(SetPasswordViewModel model)
        {
            ViewBag.Succeed = false;
            if (ModelState.isValid)
            {
                ViewBag.Succeed = WebSecurity.ResetPassword(model.UserName, model.PasswordResetToken, model.Password.NewPassword);
            }
            if (!ViewBag.Succeed)
            {
                ModelState.AddModelError("","something"); //something
            }
            return View(model);
        }
