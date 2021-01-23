    public ActionResult Create(UserModel model)
    {
        if (validate(model) {
             var user = new User();
             user.Create(model);
             return View();
        }
        else
           return RedirectToAction("Index");
    }
