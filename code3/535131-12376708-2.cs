    public class DataContext : DbContext
    {
        public DbSet<Quest> Quests { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quest>()
                .HasOptional(q => q.QuestTemplate)
                .WithRequired(qt => qt.Quest)
                .Map(m => m.MapKey("QuestId"));
        }
    }
    public class Quest
    {
        public int QuestId { get; set; }
        public string Name { get; set; }
        public virtual QuestTemplate QuestTemplate { get; set; }
    }
    public class QuestTemplate
    {
        public int QuestTemplateId { get; set; }
        public string Name { get; set; }
        public virtual Quest Quest { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (DataContext db = new DataContext())
            {
                Quest q = new Quest { Name = "Bar" };
                q.QuestTemplate = new QuestTemplate { Name = "Foo" };
                db.Quests.Add(q);
                db.SaveChanges();
            }
        }
    }
