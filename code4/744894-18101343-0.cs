    public ActionResult MoreInfo(int id)
    {    
        var e = db.AppmarketApps.Where(x => x.ID == id).FirstOrDefault();
        return View(e);
    }
