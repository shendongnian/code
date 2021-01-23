    [HttpPost]
    [Authorize]
    public ActionResult Create(MyModel model)
    {
        if (ModelState.IsValid)
        {
            model.Manpower.CreatedBy = User.Identity.Name;
            model.Manpower.CreatedOn = DateTime.Now;
            db.Manpowers.AddObject(model.Manpower);
            db.SaveChanges();
            return RedirectToAction("AddImage", new { manpower.Id});  
        }
        return RedirectToAction("Create"); //not sure why you're going back to create though?
    }
