    [HttpGet]
    public JsonResult timeHour()
    {
        var m = new MyModel();
        m.theTime = getAllTime(); // get all time
        return Json(m, JsonRequestBehavior.AllowGet)
    }
