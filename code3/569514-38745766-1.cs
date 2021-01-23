    public ActionResult Create(Campaign campaign)
    {
        ...
        campaign.CostCenters.Add(db.CostCenters.FirstOrDefault(f => f.Id == campaign.CostCenterId);
        return RedirectToAction("Index");
    }
