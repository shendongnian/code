    SomeEntity entity;
    bool adding = false;
    
    if (key > 0)
       entity = db.Entities.FirstOrDefault(i => i.Key == key);
    if (entity == null)
    {
       entity = new SomeEntity { initialvalue = "X" };
       adding = true;
    }
    
    entity.Z = someValue;
    //set other props
    
    if (adding)
       db.Entities.AddObject(entity);
    db.SubmitChanges();
