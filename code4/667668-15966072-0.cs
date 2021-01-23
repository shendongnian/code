    [HttpPost]
    public ActionResult Save(FormCollection formCollection)
    {
    
        foreach (var key in formCollection.AllKeys)
        {
            do stuff.....
    
        }
        return PartialView("_Modal");
    }
