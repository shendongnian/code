    public ActionResult MyAction()
    {
        YourModel model = new YourModel();
        model.WidgetTypes = Business.MySession.Current.WidgetTypes
            .ToSelectList(d => d.TypeName, d => d.WidgetTypeID.ToString(), " - Select - ");
        return View(model);
    }
