    public class DataContext : DbContext
    {
        public DataContext()
            : base("DataContext")
        {
        }
 
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Department> Departments { set; get; }        
    }
