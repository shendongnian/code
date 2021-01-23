    [HttpPost]
    public ActionResult Create(CreateViewModel model)
    {
        var selectedTldId = model.TldId; // this is the ID that the user selected
        var tld = GetTldById(selectedTldId); // this method would use that selected ID and retrieve the corresponding TLD entity from the database
        var d = new Domena
          {
              Cena = tld.Cena
          }
        // this gets you as far as having your Domena object with the TLD.Cena from the DB
        // ... you'd need to get a ViewModel in shape here, then return the View
        // return View(<name of model object>);
    }
