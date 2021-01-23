    [HttpPost]
    public ActionResult GetTreeUnit(string id)
    {
        int _id = id.ExtractID();
        string render = ControllerContext.RenderPartialToString("SomeView");
        return Json(new { data = render });
    }
