    [OutputCache(Duration = 86400)]
    public JsonResult GetMyData() {
        var results = QueryResults();
        return Json(results);
    }
