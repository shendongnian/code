    public ActionResult Update(string id)
    {
        FlowViewModel flv = new FlowViewModel();
        flv.Profile_GaItems = db.Profile_GaItems.ToList();
        flv.GaItems  = db.Gammes.ToList();
        return View(flv);
    }
