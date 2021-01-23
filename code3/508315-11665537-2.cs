    [HttpPost]
    public ActionResult Create(Location location)
    {
        if (ModelState.IsValid)
        {
            _locationRepository.Add(location);
            _locationRepository.Save();
            return RedirectToAction("Index");  
        }
    }
