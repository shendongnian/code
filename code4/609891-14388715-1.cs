    [HttpPost]
    public ActionResult Index(Class1 modelle)
    {
        if (ModelState.IsValid)
        {
            var user = DataAccess.DAL.GetUser(modelle.fname);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(modelle.fname, false);
                return RedirectToAction("Index", "profile");
            }
            return Content("FAIL");
        }
        return View(modelle);
    }
