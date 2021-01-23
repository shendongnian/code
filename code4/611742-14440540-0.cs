    [HttpPost]
    public ActionResult MyAction()
    {
        if (SomeCondition)
        {
            return PartialView(model);
        }
        return Json(new { redirectTo = Url.Action("TargetAction", "TargetController") });
    }
