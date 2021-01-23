       public class BaseClass
       {
          public int Id { get; set; }
          [NotMapped]
          public string InnerString { get; set; }
       }
    
       public class SubClass : BaseClass
       {
       }
    
       public class SubSubClass : SubClass
       {
       }
    
       public class MyDbcontext : DbContext
       {
          public DbSet<SubSubClass> SubSubClasses { get; set; }
          public DbSet<SubClass> SubClasses { get; set; }
       }
    
       class Program
       {
          static void Main( string[] args )
          {
             var context = new MyDbcontext();
    
             context.SubSubClasses.Add(new SubSubClass());
             context.SaveChanges();
          }
       }
