    [HttpGet]
    public ActionResult _MyPartial(string param1)
    {
        MyModel model = new MyModel();
        // This is dynamic and what I need to get in my main view from the partial view
        model.something = "Hi";
        model.somethingElse = GetHiString(param1);
        return PartialView(model);
    }
