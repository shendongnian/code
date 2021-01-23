        public class Person
        {
            [Key]
            public int Id { get; set; }
            public int PersonId { get; set; }
    
            [ForeignKey("PersonId")]
            public Person Supervisor { get; set; }
    
            public virtual ICollection<Person> SupervisedPersons { get; set; }
        }
    
        public class PersonDataContext : DbContext
        {
            public DbSet<Person> Persons { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Person>()
                    .HasKey(x => x.PersonId)
                    .HasOptional(op => op.Supervisor)
                    .WithMany(p => p.SupervisedPersons)
                    .WillCascadeOnDelete(false);
            }
        }
