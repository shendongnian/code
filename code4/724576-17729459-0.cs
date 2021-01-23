    public ActionResult Kittens() // some parameters might be here
    {
       using(var db = new KittenEntities()){ // db can also be injected,
           var result = db.Kittens // this explicit query is here
                          .Where(kitten=>kitten.fluffiness > 10) 
                          .Select(kitten=>new {
                                Name=kitten.name,
                                Url=kitten.imageUrl
                          }).Take(10); 
           return Json(result,JsonRequestBehavior.AllowGet);
       }
    }
