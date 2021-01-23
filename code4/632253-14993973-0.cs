    [HttpPost]
    public ActionResult FormOnePost(ModelFromFormOne modelFromFormOne)
    {
        var model = modelFromFormOne.Id; // Just a simple int
        return View("ViewTwoWithSecondForm", model);
    }
    public ActionResult ViewTwoWithSecondForm(int id)
    {
        var model = new MoreComplexModel();
        model.Filters = IList<Filter> from database? query using id
        model.MoreStuff etc.
        return View(model);
    }
