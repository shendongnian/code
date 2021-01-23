    public class Publication
    {
        public int PublicationId { get; set; }
        public string PublicationName { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
    
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public ICollection<Publication> Publications { get; set; }
    }
    
    public class Context : DbContext
    {
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
    
            Context context = new Context();
    
            // Only add the groups if it's a new database
            if (!context.Groups.Any())
            {
                context.Groups.Add(new Group { GroupName = "Group 1" });
                context.Groups.Add(new Group { GroupName = "Group 2" });
                context.SaveChanges();
            }
    
            if (context.Publications.Any())
            {
                Console.WriteLine("At startup, P1 is in groups " + String.Join(", ", context.Publications.First().Groups.Select(g => g.GroupName)));
            }
    
            // Add publication
            Publication p;
            p = new Publication();
            p.Groups = context.Groups.ToList();     // Add to all existing groups
            context.Publications.Add(p);
            context.SaveChanges();
    
            Console.WriteLine("P1 is in groups " + String.Join(", ", context.Publications.First().Groups.Select(g => g.GroupName)));
        }
    }
