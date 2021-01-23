    public ActionResult Validate([Bind(Prefix = "item")] MyViewModel model)
    {
        return Json(
            !string.IsNullOrEmpty(model.Prop3), 
            JsonRequestBehavior.AllowGet
        );
    }
