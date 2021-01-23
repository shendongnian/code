    Entity newEntity = new Entity();   
    Eneity Entity = db.Include("ChildEntity").Where(p=>p.Id==Id).Single();   
    newEntity = DeepClone<Entity>(Entity);   
    db.Detach(myEntity);    
    db.SaveChanges();  
    myEntity.EntityKEy = null;   
    db.Entities.AddObject(newEntity);   
    db.SaveChanges();  
