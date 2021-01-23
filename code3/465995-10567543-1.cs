    class Program
    {
        static void Main(string[] args)
        {
            ContactsEntities entities = new ContactsEntities();
            Address doeaddress = new Address() { Street = "1 Broadway", ZipCode = "01234" };
            entities.Addresses.Add(doeaddress);
            entities.Persons.Add(new Person() { FirstName = "Jane", LastName = "Doe", Address = doeaddress });
            entities.Persons.Add(new Person() { FirstName = "John", LastName = "Doe", Address = doeaddress });
            entities.SaveChanges();
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
    [Table("Addresses")]
    public partial class Address
    {
        public Address()
        {
            this.Persons = new HashSet<Person>();
        }
        [Key]
        public int AddressID { get; set; }
        [Required]
        public string Street { get; set; }
        [RegularExpression(@"^(\d{5}-\d{4}|\d{5}|\d{9})$")]
        [Required]
        public string ZipCode { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
    [Table("Persons")]
    public partial class Person
    {
        [Key]
        public int PersonID { get; set; }
        public int AddressID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [ForeignKey("AddressID")]
        public virtual Address Address { get; set; }
    }
    public partial class ContactsEntities : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
