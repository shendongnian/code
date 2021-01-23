    [HttpPost]
    public ActionResult Edit(CitizenEntryViewModel citizenDetails)
    {
        ActiveCitizen activeCitizen = db.ActiveCitizen.SingleOrDefault(m => m.ID == citizenDetails.ActiveCitizen.ID);
        if (activeCitizen != null)
        {
            UpdateModel(activeCitizen);
            db.SaveChanges();
        }
