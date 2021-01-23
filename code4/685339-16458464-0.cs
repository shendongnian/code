    if (!ValidateLogOn(Matricule, passWord))
    {
        return Connection(Matricule, passWord);
    }
    public ActionResult Connection(string Matricule, string passWord)
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
