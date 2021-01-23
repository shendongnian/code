    SMEntities newContext = new SMEntities();
    foreach(var product in products)
    {
       newContext.Attach(product);
       db.Entry(product).State = EntityState.Modified;
    }
    newContext.SaveChanges();
