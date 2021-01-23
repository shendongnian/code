    public ActionResult Create(Thingy model)
    {
        var thing = _collection.FindOneAs<Thingy>(Query.EQ("UUID", model.UUID));
        if(thing == null)
        {
           thing = new Thingy{
                             TimeCreated = DateTime.Now,
                             UUID = System.Guid.NewGuid().ToString(),
                             Id = ObjectId.GenerateNewId()
                            }
        }
        else 
        {
           thing.Content = model.Content;
           //other updates here
        }
        _collection.Save<Thingy>(thing);
        return View();
    }
