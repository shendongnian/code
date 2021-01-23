    [HttpGet]
    public ActionResult Index(int userId)
    {
        return View(new UserViewModel(userId));
    }
