    using(var ctx = new MyContext())
    {
       var dummyEntity = new MyEntity{ Id = 1 };
       ctx.MyEntities.Attach(dummyEntity); // EF now knows you have an entity with ID 1 in your db but none of its properties have changed yet
       dummyEntity.SomeProperty = 1; //the change to SomeProperty is now tracked
       ctx.SaveChanges();// a single update is called to set entity with Id 1's 'SomeProperty' to 1  
    }
