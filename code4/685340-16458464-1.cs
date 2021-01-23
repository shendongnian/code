    public ActionResult LogOn(string Matricule, string passWord, bool rememberMe, string returnUrl)
    {
        if (!ValidateLogOn(Matricule, passWord))
        {
            return Connection(Matricule, passWord, returnUrl);
        }
        
        FormsAuth.SignIn(Matricule, rememberMe);
        if (!String.IsNullOrEmpty(returnUrl))
        {
            return Redirect(returnUrl);
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }
    public ActionResult Connection(string Matricule, string passWord, string returnUrl)
    {
        List<User> users = db.Users.ToList();
        ActionResult output = null;
        if (users.Any())
        {
            foreach (User u in users)
            {
                if ((u.Matricule == Matricule) && (u.passWord == passWord))
                {
                    output = View();
                }
            }
        }
        else
        {
            output = Redirect(returnUrl);
        }
        return output;
    }
