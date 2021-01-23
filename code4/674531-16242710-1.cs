    [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _authenticationService.Login(model);
                if (user != null)
                {
                    _cookieHelper.SetCookie(user);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect username or password");
                return View(model);
            }
            return View(model);
        }
