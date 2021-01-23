    public class Publication
    {
        public int PublicationId { get; set; }
    
        [InverseProperty("Publications")]
        public virtual ICollection<Group> Groups { get; set; }
    }
    
    public class Group
    {
        public int GroupId { get; set; }
    
        [InverseProperty("Groups")]
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
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
            Context context = new Context();
    
            Group g1, g2;
            context.Groups.Add(g1 = new Group());
            context.Groups.Add(g2 = new Group());
    
            Publication p1;
            p1 = new Publication();
            context.Publications.Add(p1);
    
            // Are you saving here (i.e. Group and Publication stored before links added)
            context.SaveChanges();
            p1.Groups = context.Groups.ToList();
    
            context.SaveChanges();
    
            Console.WriteLine("P1 is in groups " + String.Join(", ", context.Publications.First().Groups.Select(g => g.GroupId)));
        }
    }
