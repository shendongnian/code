    public ActionResult Index(int id)
    {
        UserModel model = db.Users.Where(u => u.Id == id).SingleOrDefault();
        return View(model);
    }
