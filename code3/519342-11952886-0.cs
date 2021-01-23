    public ActionResult SignIn(SignInModel model)
        {
            string domainName = CheckSignIn.GetDomainName(model.User.UserName);
            string userName = CheckSignIn.GetUserName(model.User.UserName);
            IntPtr token = IntPtr.Zero;
            bool result = CheckSignIn.LogOnUser(userName, domainName, model.User.UniqueUserCode, 2, 0, ref token);
            if (result)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]) && Request.QueryString["ReturnUrl"] != "/")
                {
                    FormsAuthentication.RedirectFromLoginPage(model.User.UserName, false);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(model.User.UserName, false);
                    return RedirectToAction("MyVoyages", "Voyage");
                }
            }
            return SignIn(true);
        }
