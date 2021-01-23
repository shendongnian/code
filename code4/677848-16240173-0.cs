    public JsonResult TestArray(int? id)
    {
        string[] test = new string[] { "test1", "test2", "test3", "test4", "test5" };
        return Json(test, JsonRequestBehavior.AllowGet);
    }
