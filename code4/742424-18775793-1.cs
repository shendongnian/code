    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Meeting> MeetingsAsCustomer { get; set; }
        public virtual ICollection<Meeting> MeetingAsSalesAgent { get; set; }
    }
    public class Meeting
    {
        public int MeetingID { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Person Customer { get; set; }
        [ForeignKey("SalesAgent")]
        public int SalesAgentID { get; set; }
        public virtual Person SalesAgent { get; set; }
    }
    public class MyContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meeting>().HasRequired(m => m.Customer).WithMany(p => p.MeetingsAsCustomer);
            modelBuilder.Entity<Meeting>().HasRequired(m => m.SalesAgent).WithMany(p => p.MeetingAsSalesAgent);
        }
