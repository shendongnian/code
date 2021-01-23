    [HttpPost]
    public ActionResult Create(MyEntity entity)
    {
         entity.Id = Guid.NewGuid();
         entity.DateAdded = DateTime.Now;
         entity.DateChanged = DateTime.Now;
         // the name will be added from the view
         db.MyContext.Add(entity);
         db.Save(); 
    }
