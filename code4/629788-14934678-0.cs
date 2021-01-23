    public interface ILuw
       OperationStatus Commit();
      public class UoW : IUow
    {
      // Constructor... inject context....
         // Properties/Members that work with your repository Interface pattern
         
          public DbSet<Users> Users  // example
          public DbSet<Entity2>
       public OperationStatus Commit()
        {
         Context.SaveChanges();
         }
    
 
    }
