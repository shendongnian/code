    public ActionResult CheckLogin()
    {
        if (Request.Cookies["CookieName"] == null) return Json(0, JsonRequestBehavior.AllowGet);
        var cookie = Request.Cookies["CookieName"].Value;
        var ticket = FormsAuthentication.Decrypt(cookie);
        var secondsRemaining = Math.Round((ticket.Expiration - DateTime.Now).TotalSeconds, 0);
        return Json(secondsRemaining, JsonRequestBehavior.AllowGet);
    }
