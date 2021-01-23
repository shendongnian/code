    public class a
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public virtual b b { get; set; }
        
        public int? b_Id { get; set; }
        public virtual c c { get; set; }
        
        public int? c_Id { get; set; }
    }
    public class b
    {
        public int Id { get; set; }
        public string name { get; set; }
        public virtual ICollection<a> a_s { get; set; }
        public virtual ICollection<c> c_s { get; set; }
    }
    public class c
    {
        public int Id { get; set; }
        public virtual b b { get; set; }
        
        public int? b_Id { get; set; }
        public virtual ICollection<a> a_s { get; set; }
    }
    public class NreContext : DbContext
    {
        public DbSet<a> a { get; set; }
        public DbSet<b> b { get; set; }
        public DbSet<c> c { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<a>()
                .HasOptional(m => m.b)
                .WithMany(m => m.a_s)
                .HasForeignKey(m => m.b_Id);
            modelBuilder.Entity<a>()
                .HasOptional(m => m.c)
                .WithMany(m => m.a_s)
                .HasForeignKey(m => m.c_Id);
            modelBuilder.Entity<c>()
                .HasOptional(m => m.b)
                .WithMany(m => m.c_s)
                .HasForeignKey(m => m.b_Id);
            base.OnModelCreating(modelBuilder);
        }
    }
