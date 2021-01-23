    using(ModelContainer DBContext = new ModelContainer())
    {
    
        foreach (var user in users) 
        { 
            var u = (from q in DBContext.Users 
             where q.Name == user 
             select q).FirstOrDefault(); 
       
            if(u!=null)
            {
                u.IsActive = true;
            }
      }
      DBContext.SaveChanges(); //Save changes once, and not per user. Unless you can but I doubt it.
    }
