    public ActionResult SomeAction() {
        MyViewModel model;
        model = new MyViewModel();
        //Populate the good stuff here.
        return View(model);
    }
    [HttpPost]
    public ActionResult SomeAction(MyViewModel model) {
        //Do something with the data in the model object.
    }
