    [HttpPost]
    public ActionResult Create(ExampleViewModel model)
    {
        if (ModelState["User.RegistrationNumber"].Errors.Count == 1) {
            model.User.RegistrationNumber = this.RegistrationNumber;
            ModelState["User.RegistrationNumber"].Errors.Clear();
        }
    }
