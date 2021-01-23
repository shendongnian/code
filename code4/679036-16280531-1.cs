    public class Wheel 
    {
      public int ID { get; set; }
      public int CarID { get; set; }
    }
    modelBuilder
        .Entity<MyParentEntity>()
        .HasMany(_ => _.Children)
        .WithRequired() //.WithOptional()
        .HasForeignKey(_ => _.ParentId);
