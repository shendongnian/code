    public ActionResult Gestion(FlowViewModel model)
    {
        model.YourGammeModel = new Gamme();
        
        return PartialView(model);
     }
