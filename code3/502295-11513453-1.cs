    //This is your initial HTTP GET request.
    public ActionResult SomeAction() {
        MyViewModel model;
        model = new MyViewModel();
        //Populate the good stuff here.
        return View(model);
    }
    //Here is your HTTP POST request; notice both actions use the same model.
    [HttpPost]
    public ActionResult SomeAction(MyViewModel model) {
        //Do something with the data in the model object.
    }
