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
    
        public class Person 
        {
            [Key]
            public long PersonId { get; set; }
            public virtual PhoneNumber PhoneNumber { get; set; }
        }
    
    
        public class PhoneNumber
        {
            [Key,ForeignKey("person")]
            public long PhoneNumberId { get; set; }
    
            
    
           
            public virtual Person person { get; set; }
        } 
    
       public class Program
        {
           
            static void Main(string[] args)
            {
                var realNumber = new PhoneNumber();
                var person = new Person()  {PhoneNumber = realNumber};
                var context = new TestContext();
                context.Persons.Add(person);
                context.SaveChanges();
               
                
            }
        }
    }
