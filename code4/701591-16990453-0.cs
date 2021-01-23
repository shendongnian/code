            [HttpPost]
            public ActionResult LogIn(AuthViewModel authResult)
            {
                if (!this.ControllerContext.IsChildAction)
                {
                    if (ModelState.IsValid)
                    {
                        userService.LogInUser(authResult.Login, authResult.Password, Request.UserHostAddress);
                    }
                    else
                    {
                        TempData["AuthMessage"] = GetValidationMessage();
                    }
                    string redirectUrl = "/";
                    if (Request.UrlReferrer != null)
                    {
                        redirectUrl = Request.UrlReferrer.AbsoluteUri.ToString();
                    }
                    return Redirect(redirectUrl);
                }
                ModelState.Clear();
                return PartialView("AuthControl");
            }
