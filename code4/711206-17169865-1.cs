    public ActionResult Register()
    {
        if (!HttpContext.User.Identity.IsAuthenticated)
        {
            return View();
        }
        else
        {
            return RedirectToAction("Index");
        }
    }
