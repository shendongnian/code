        static void Main(string[] args)
        {
            using (ContactsEntities entities = new ContactsEntities())
            {
                entities.Persons.Add(new Person() { FirstName = "Jane", LastName = "Doe", Photo = new Photo() { PhotoLink = "/images/jane.jpg" } });
                entities.Persons.Add(new Person() { FirstName = "John", LastName = "Doe" }); // no photo
                entities.Persons.Add(new Person() { FirstName = "Joe", LastName = "Smith", Photo = new Photo() { PhotoLink = "/images/joe.jpg", ThumnbnailLink = "/images/thumbs/joe.jpg" } });
                // note that the following is not allowed based on the defined RI rules - will fail on call to SaveChanges:
                // entities.Photos.Add(new Photo() { PhotoLink = "/images/as.jpg" });
                entities.SaveChanges();
                foreach (Person person in entities.Persons)
                {
                    Console.WriteLine("{0} {1} {2}", person.FirstName, person.LastName, person.Photo == null ? "missing photo" : person.Photo.PhotoLink);
                } 
            }
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
    public partial class ContactsEntities : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // a Person may have at most one Photo
            modelBuilder.Entity<Person>().HasOptional<Photo>(p => p.Photo);
            // a Photo is dependant on a Person (non-nullable FK constraint)
            modelBuilder.Entity<Photo>().HasRequired<Person>(p => p.Person);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
    [Table("Photos")]
    public partial class Photo
    {
        [Key]
        public int PhotoID { get; set; }
        [Required]
        public string PhotoLink { get; set; }
        public string ThumnbnailLink { get; set; }
        public virtual Person Person { get; set; }
    }
    [Table("Persons")]
    public partial class Person
    {
        [Key]
        public int PersonID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual Photo Photo { get; set; }
    }
