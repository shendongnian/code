    public ActionResult SomeAction(string selectedFunction, string someOtherValue) 
    {
        IEnumerable<SomeResultModel> results = ...
        return PartialView(results);
    }
