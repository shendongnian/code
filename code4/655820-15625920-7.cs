    modelBuilder.Entity<QuestionOption>()
        .HasKey(i => new { i.OptionID, i.QuestionLeftID, i.QuestionRightID });
    modelBuilder.Entity<QuestionOption>()
        .HasRequired(i => i.Opiton)
        .WithMany(u => u.DependencyOptions)
        .HasForeignKey(i => i.OptionID)
        .WillCascadeOnDelete(false);
    modelBuilder.Entity<QuestionOption>()
        .HasRequired(i => i.QuestionLeft)
        .WithMany(u => u.DependencyOptionsLeft)
        .HasForeignKey(i => i.QuestionLeftID)
        .WillCascadeOnDelete(false);
    modelBuilder.Entity<QuestionOption>()
        .HasRequired(i => i.QuestionRight)
        .WithMany(u => u.DependencyOptionsRight)
        .HasForeignKey(i => i.QuestionRightID)
        .WillCascadeOnDelete(false);
    modelBuilder.Entity<Option>()
        .HasRequired(i => i.Question)
        .WithMany(u => u.Options)
        .HasForeignKey(i => i.QuestionId)
        .WillCascadeOnDelete(false);
    public class Question
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Option> Options { get; set; }
        public virtual ICollection<QuestionOption> DependencyOptionsLeft { get; set; }
        public virtual ICollection<QuestionOption> DependencyOptionsRight { get; set; }
    }
    public class QuestionOption
    {
        public long QuestionLeftID { get; set; }
        public Question QuestionLeft { get; set; }
        public long QuestionRightID { get; set; }
        public Question QuestionRight { get; set; }
        public long OptionID { get; set; }
        public Option Opiton { get; set; }
        public int DependencyType { get; set; }
        public string DependencyNote { get; set; }
        public bool Active { get; set; }
        public bool AllowForbid { get; set; }
    }
