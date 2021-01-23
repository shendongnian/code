    public ActionResult MyAction()
    {
        var model = new SomethingModel {
            FirstName = "John",
            LastName = "Doe",
            PostCode = "XXY XXY"
        };
        return View(model);
    }
