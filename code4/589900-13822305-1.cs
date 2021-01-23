    public ActionResult Authenticate(string username,string password)
    {
        bool status = Login.Authenticate(username, password);
        return View("Status", status);
    }
