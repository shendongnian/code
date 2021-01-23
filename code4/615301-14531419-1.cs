    [HttpGet]
    [RequireHttps]
    public ActionResult LogOn(string returnUrl)
    {
         if (string.IsNullOrWhiteSpace(returnUrl))
           returnUrl = "/reports";
         return LogOnCommon(returnUrl);
    }
