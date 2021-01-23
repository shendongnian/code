    Entity newEntity = new Entity();
    Entity entity = db.Include("ChildEntity").Where(p => p.Id == Id).Single();
    newEntity = entity.DeepClone(); // assuming you've put your DeepClone extension method in a static class so that it can be used as an extension
    newEntity.EntityKey = null;
    foreach(var childEntity in newEntity.ChildEntities)
    {
        childEntity.EntityKey = null;
    }
    db.Entities.AddObject(newEntity);
    db.SaveChanges();
