    public ViewResult Index()
    {
       var currentUser = Customer.Where(c => c.UserName == HttpContext.User.Identity.Name);
       return View(currentUser);
    }
