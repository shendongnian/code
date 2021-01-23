        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult PasswordReset(PasswordReset model, string passwordToken)
        {
            //Attemp to change password
            model.PasswordResetToken = passwordToken;
            var passwordChangeConfirmation = WebSecurity.ResetPassword(model.PasswordResetToken, model.Password);
            //Password has been changed
            if (passwordChangeConfirmation == true)
            {
                return RedirectToAction("Index", "Home");
            }
            //Password change has failed
            else
            {
                return RedirectToAction("Error", "Account");
            }
        }
