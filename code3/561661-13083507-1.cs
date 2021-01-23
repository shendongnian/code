    public ActionResult Index(string limba, int id, string titluPagina)
    {
        // Set the language to default, if none given (via /Art-10/title route)
        if (string.IsNullOrEmpty(limba)) limba = "en";
        // Your actual stuff here
        return View();
    }
