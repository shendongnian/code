        class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
            var p = new Parent();
            var c = new Child();
            using (var db = new Context())
            {
                db.Parents.Add(new Parent());
                db.Parents.Add(p);
                db.Children.Add(c);
                db.SaveChanges();
            }
            using (var db = new Context())
            {
                var reloadedP = db.Parents.Find(p.ParentId);
                var reloadedC = db.Children.Find(c.ChildId);
                reloadedP.Children = new List<Child>();
                reloadedP.Children.Add(reloadedC);
                db.SaveChanges();
            }
            using (var db = new Context())
            {
                Console.WriteLine(db.Children.Count());
                Console.WriteLine(db.Children.Where(ch => ch.ChildId == c.ChildId).Select(ch => ch.Parents.Count).First());
                Console.WriteLine(db.Parents.Where(pa => pa.ParentId == p.ParentId).Select(pa => pa.Children.Count).First());
            }
        }
    }
    public class Parent
    {
        public int ParentId { get; set; }
        public ICollection<Child> Children { get; set; }
    }
    public class Child
    {
        public int ChildId { get; set; }
        public ICollection<Parent> Parents { get; set; }
    }
    public class Context : DbContext
    {
        public Context() : base("data source=Mikael-PC;Integrated Security=SSPI;Initial Catalog=EFTest")
        {
        }
        public IDbSet<Child> Children { get; set; }
        public IDbSet<Parent> Parents { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Child>()
                .HasMany(x => x.Parents)
                .WithMany(x => x.Children)
                .Map(c =>
                {
                    c.MapLeftKey("ChildId");
                    c.MapRightKey("ParentId");
                    c.ToTable("ChildToParentMapping"); 
                });
        }
    }
