    namespace Ef1to1
    {
        public class TestContext : DbContext
        {
    
            public TestContext()
                : base("Data Source=127.0.0.1;database=Junk;Integrated Security=SSPI;")
            {
    
            }
            public DbSet<Person> Persons { get; set; }
            public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        }
        [Table("Person")]
        public class Person 
        {
            [Key, Column("PersonId")]
            public long Id { get; set; }
            
            public virtual PhoneNumber phoneNumber { get; set; }
        }
    
        [Table("PhoneNumber")]
        public class PhoneNumber
        {
           
            [Key, Column("PhoneNumberId"), ForeignKey("person")]
            public long Id { get; set; }
    
            public virtual Person person { get; set; }
        } 
    
       public class Program
        {
           
            static void Main(string[] args)
            {
                var realNumber = new PhoneNumber();
                var person = new Person() { phoneNumber = realNumber }; 
                var context = new TestContext();
               
                context.Persons.Add(person) ;
                context.SaveChanges();
                ;
                
            }
        }
    }
