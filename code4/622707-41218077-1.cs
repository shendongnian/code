    [HttpPost]
    public ActionResult MyAction(MyModel model)
    {
        model.Remember = model.Remember ?? false;
        Console.WriteLine(model.Remember.ToString());
    }
