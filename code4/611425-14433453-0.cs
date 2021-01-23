    [HttpPost]
    public ActionResult StudentSearchResult(/*other stuff I send here, */ string[] studentNames)
    {
        StudentSearchResult model = ... //stuff here to populate your view model
        return Json(model);
    }
