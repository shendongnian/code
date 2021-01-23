    [HttpPost]
    public ActionResult Edit(Category c)
    {
    	var cateogry = _db.Categories.Where(x => x.ID == c.ID).Single();
    
    	if (TryUpdateModel(cateogry))
    	{
    		cateogry.UpdatedDateTime = DateTime.Now;
    		_db.SaveChanges();
    	}
    
    	return Redirect("/admin/category");
    }
