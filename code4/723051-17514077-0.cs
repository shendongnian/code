    protected void Application_Start() {
         // ... 
    
         // Initializes and seeds the database.
         Database.SetInitializer(new MyDBInitializer());
     
         // Forces initialization of database on model changes.
         using (var context = new ApplicationDB()) {
              context.Database.Initialize(force: true);
         }
    
         // ...
    }
