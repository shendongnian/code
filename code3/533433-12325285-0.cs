    public class Customer
    {
        [StringLength(5)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(30)]
        public string Email { get; set; }
        [StringLength(30)]
        public string Address { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Customer c = new Customer 
            {
                Name = "FooBarX",
                Phone = "555-5555-33 ext 234",
                Email = "foobar@foobar.com",
                Address = "1334 foobar ave, foobar CA"
            };
            var ctx = new ValidationContext(c, null, null);
            Validator.ValidateObject(c, ctx,true);
            Console.Read();
        }
    }
