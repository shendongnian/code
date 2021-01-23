    [HttpPost]
    public ActionResult FormOnePost(ModelFromFormOne modelFromFormOne)
    {
        var model = new ModelForFormTwo();
        model.Filters = IList<Filter> from database? query using id
        model.MoreStuff etc.
        return View("ViewTwoWithSecondForm", model);
    }
