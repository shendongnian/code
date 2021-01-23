    public ActionResult VerifyLogin()
    {
        if (Session["isLogged"] != null || (int)Session["isLogged"] != 1)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }
