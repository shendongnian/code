    public class Person
     {
         public int? FatherId { get; set; }
         public virtual Person Father { get; set; }
         public int? MotherId { get; set; }
         public virtual Person Mother { get; set; }
         public virtual List<Person> ChildrenAsFather { get; set; }
         public virtual List<Person> ChildrenAsMother { get; set; }
     }
    
     class PersonConfiguration : EntityTypeConfiguration<Person>
     {
         public PersonConfiguration()
         {
             HasOptional(e => e.Father).WithMany(e => e.ChildrenAsFather)
                  .HasForeignKey(e => e.FatherId);
             HasOptional(e => e.Mother).WithMany(e => e.ChildrenAsMother)
                  .HasForeignKey(e => e.MotherId);
         }
     }
