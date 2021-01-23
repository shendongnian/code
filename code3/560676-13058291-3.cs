    [HttpPost]
    public ActionResult SearchResult(FormCollection values)
    {
        string carModel  = values["model"];
    
         using( ICarRepository myRepository = _createRepository( carModel)) 
         {
                ... 
         } 
    }
