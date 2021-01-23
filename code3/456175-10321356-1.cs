    public class ObjectA
    {
        public Guid Id {get; set;}
    }
    public class ObjectB
    {
        public Guid Id {get; set;}
        public Guid ObjectAId {get; set;}
        public virtual ObjectA ObjectA {get; set;}
    }
    modelBuilder.Entity<ObjectB>()
        .HasRequired(b => b.ObjectA)
        .WithMany()
        .HasForeignKey(b => b.ObjectAId)
        .WillCascadeOnDelete(false); 
