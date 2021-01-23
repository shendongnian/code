    routes.Add("someRoute",
        "{controller}/{action}/{controlId}",
        new { controller = "Home", action = "Index", controlId = UrlParameter.Optional }
        );
    public ActionResult Index(int? controlId)
    {
    }
