    public class Person
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
    
        public int AccessCodeId { get; set; }
        public virtual AccessCode AccessCode { get; set; }
    }
    
    public class AccessCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
    }
    
    public class MyContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<AccessCode> AccessCodes { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<MyContext>(new DropCreateDatabaseAlways<MyContext>());
    
            var context = new MyContext();
    
            var person = new Person
            {
                FirstName = "Nadege",
                LastName = "Deroussen",
                BirthDate = DateTime.Now,
                AccessCode = new AccessCode { Code = "ABC" }
            };
            context.Persons.Add(person);
    
            var accessCode = new AccessCode { Code = "MGH" };
            context.AccessCodes.Add(accessCode);
            context.SaveChanges();
    
    
            var person2 = context.Persons.FirstOrDefault();
            person2.AccessCodeId = 2;
            // or person2.AccessCode = accessCode;
    
            context.SaveChanges();
    
            Console.Write("Person saved !");
            Console.ReadLine();
        }
    }
