    public ActionResult TryMeOut()
    {
       TempData["ReturnPath"] = Request.UrlReferrer.ToString();
       //return your users to the correct view.
    }
