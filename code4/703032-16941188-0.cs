    [HttpPost]
    public ActionResult PlaceTag(PlacesWithTagsViewModel model)
    {
        if (ModelState.IsValid)
        {
           tag tagtest = GetTagById(model.tagid);
           tag.name= model.tag.name;
           tag.nameplural = model.tag.nameplural;
           UpdateModel(tag, "model");
           db.SaveChanges();
           return RedirectToAction("Index", "Dashboard", new { id = 5 });
        } 
    }
