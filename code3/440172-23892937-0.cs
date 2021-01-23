    public ActionResult Index()
    {
    string Domain = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host +       (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
    return View(Domain);
    }
