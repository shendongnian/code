    public ActionResult Stellenliste()
    {
        var viewModels = new[] 
        { 
            new StellenlisteViewModel { StellenListe = _repository.ListAktuell()} 
        };
        return View(viewModels);
    }
