    [HttpPost]
    public ActionResult Create(Location location)
    {
        if (ModelState.IsValid)
        {
            Validations v = new Validations();
            Boolean ValidProperties = true;
            EmptyResult er;
            string sResult = v.Validate100CharLength(location.Name, location.Name);
            if (sResult == "Accept")
            {
                ValidProperties = true;
            }
            else
            {
                ValidProperties = false;
                ModelState.AddModelError("", "sResult is not accepted! Validation failed");
            }
             if (ValidProperties == true)
             {
                 db.Locations.Add(location);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }
        }
        ViewBag.OwnerId = new SelectList(
                            db.Employees, "Id", "FirstName", location.OwnerId);
        return View(location);
    }
