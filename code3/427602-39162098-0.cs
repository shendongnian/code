     public class My Context : DbContext {
      public MyContext()
      {
            // REMOVE this or use veblok's solution
            this.Configuration.AutoDetectChangesEnabled = false;            
      }
      ...
     }
