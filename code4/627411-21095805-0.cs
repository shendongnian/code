    [HttpPost]
    public ActionResult LogOn(LogOnModel model, string returnUrl)
    {
       //... omitted some preliminary validation ...
       return Redirect(returnUrl);
    }
