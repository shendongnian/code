    [HttpPost]
    public ActionResult Foo(MyViewModel model)
    {
        // model.BusinessSubCategories should contain a list of Subcategory
        // where for each element you could use the Flag property to see if
        // it was selected or not
        ...
    }
