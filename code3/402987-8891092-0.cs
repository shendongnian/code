    public partial class MyEntities: DbContext
    {
        public MyEntities()
            : base("name=MyEntities")
        {
        }
    
        public DbSet<Assignee> AssigneesSet { get; set; }
    
        public IQueryable<Assignee> Assignees 
        {
            get
            {
                return AssigneesSet.Where(z => z.IsActive == true);
            }
        }
    }
