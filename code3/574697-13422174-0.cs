    using (DbEntities ctx = new DbEntities())
    {
        // Create new Group
        Group g = new Group() { name = "Some name", };
 
        //Create new User 1
        User u1 = new User() { firstname = "user 1", };
        
        //Create new User 2
        User u2 = new User() { firstname = "user 2", };
 
        // Add users to the Group
        g.owner.Add(u1);
        g.owner.Add(u2);
 
        //Updating the context
        ctx.AddToGroup(d);
 
        //Save to Database
        ctx.SaveChanges();
    }
