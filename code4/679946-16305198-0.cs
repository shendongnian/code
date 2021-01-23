     public ActionResult MyAction(int id)
     {
        var asset = db.Assets.Single(a => a.Id == Id).Include(a => a.AssetCategory);
        
        return View(asset);
     }
