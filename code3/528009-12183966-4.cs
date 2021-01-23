    public ActionResult Example()
    {
        ExampleViewModel model = new ExampleViewModel();
        return This.View(model);
    }
    [HttpPost]
    public ActionResult Example(ExampleViewModel model)
    {
        string infoEntered = model.TextBoxData;
        // Do something with infoEntered
    }
