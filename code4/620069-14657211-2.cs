    public class Car
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CarConfiguration : EntityTypeConfiguration<Car>
    {
        public CarConfiguration()
        {
            HasKey(i => i.Id);
            HasRequired(i => i.Person).WithMany().HasForeignKey(i => i.PersonId).WillCascadeOnDelete(false);
        }
    }
