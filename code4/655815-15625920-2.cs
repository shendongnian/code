    public class QuestionContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionOption>()
                .HasKey(i => new { i.OptionID, i.QuestionID });
            modelBuilder.Entity<QuestionOption>()
                .HasRequired(i => i.Opiton)
                .WithMany(u => u.DependencyOptions)
                .HasForeignKey(i => i.OptionID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<QuestionOption>()
                .HasRequired(i => i.Question)
                .WithMany(u => u.DependencyOptions)
                .HasForeignKey(i => i.QuestionID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Option>()
                .HasRequired(i => i.Question)
                .WithMany(u => u.Options)
                .HasForeignKey(i => i.QuestionId)
                .WillCascadeOnDelete(false);
        }
    }
    public class Question
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Option> Options { get; set; }
        public virtual ICollection<QuestionOption> DependencyOptions { get; set; }
    }
    public class Option
    {
        public long Id { get; set; }
        public string Text { get; set; }
        // [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
        public long QuestionId { get; set; }
        public virtual ICollection<QuestionOption> DependencyOptions { get; set; }
    }
    public class QuestionOption
    {
        public long OptionID { get; set; }
        public Option Opiton { get; set; }
        public long QuestionID { get; set; }
        public Question Question { get; set; }
        public int DependencyType { get; set; }
        public string DependencyNote { get; set; }
        public bool Active { get; set; }
        public bool UseEtc { get; set; }
    }
