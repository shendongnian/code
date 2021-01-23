    public ActionResult SomeAction(string SomeData)
    {
        var result = data from your db;
        
        Json(result, JsonRequestBehavior.AllowGet);
    }
    
