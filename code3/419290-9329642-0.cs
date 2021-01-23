    public class MyDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
    
        public IQueriable<Task> TaskSource 
        { 
           get 
           { 
              return Tasks.Where(t => t.LastUpdate < EntityFunctions.AddDays(DateTime.Now, 3)); 
           }
        }
    }
