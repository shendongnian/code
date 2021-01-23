    public ActionResult AutoComplete(string term)
    {
        BuSIMaterial.Models.BuSIMaterialEntities db = new Models.BuSIMaterialEntities();
    
        //var result = new [] {"A","B","C","D","E","F"}; with this, it works
    
        var result = db
            .Persons
            .Where(p => p.FirstName.ToLower().Contains(term.ToLower()))
            .Select(p => p.FirstName) // <!-- That's the important bit you were missing
            .ToList();
    
        return Json(result, JsonRequestBehavior.AllowGet);
    }
