    [HttpPost]
    public ActionResult QuerySomthing(FormCollection formCollection)
    {
    	var query = new Status(); // Complext Data Model for Search
    	query.States = formCollection["StatesQuery"].Split(',');
    	... etc
    	var model = new SearchViewModel(); // ViewModel for Partial
    	model.StatusSummaries = _submissionsDataProvider.DoQuery(query);
    	return View("SearchResults", model);
    }
