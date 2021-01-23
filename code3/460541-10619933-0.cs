    public class Customer
    {
        // so we need to supply unique keys manually
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());
            using (var ctx = new MyContext())
            {
                var customer = new Customer { Id = 1, Name = "X" };
                ctx.Customers.Add(customer);
                ctx.SaveChanges();
            }
            // Now customer 1 is in database
            using (var ctx = new MyContext())
            {
                var customer = new Customer { Id = 1, Name = "Y" };
                ctx.Customers.Add(customer);
                try
                {
                    ctx.SaveChanges();
                    // will throw an exception because customer 1 is already in DB
                }
                catch (DbUpdateException e)
                {
                    // customer is still attached to context and we only
                    // need to correct the key of this object
                    customer.Id = 2;
                    ctx.SaveChanges();
                    // no exception
                }
            }
        }
    }
