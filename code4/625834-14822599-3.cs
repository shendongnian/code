    public JsonResult InAction(string id)
    {
        // get some object from repository
        var repository = new ObjectRepository();
        var returnObj = repository.GetObject(id);
        return Json(returnObj, JsonRequestBehavior.AllowGet);
    }
