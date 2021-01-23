    foreach (var item in updated)
    {
       var original = db.MyEntities.Find(item.Id);
       db.Entry(original).CurrentValues.SetValues(item);
    }
    db.SaveChanges();
