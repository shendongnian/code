       using (var context = new MyContext())
       {
           context.MyEntities.AddObject(newObject);
           context.SaveChanges();
           int id  = newObject.Id; // Will give u the autoincremented ID
       }
