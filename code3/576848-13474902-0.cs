    public ActionResult ActiveCampaigns()
    {
        var campaigns = db.ActiveCampaigns.Take(5).ToList();
        return View(campaigns);
    }
