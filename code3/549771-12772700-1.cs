    public ActionResult Detail(int? playerId)
    {
       if(playerId.HasValue)
       {
           var model = _dataSource.Players.Single(p => p.PlayerId == playerId);
    
           return View(model);
       }
    
       // Handle the other possibility where playerId is NULL
    }
