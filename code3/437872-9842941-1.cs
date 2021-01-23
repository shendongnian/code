    using System.Data;
    using System.Data.Entity;
    namespace EFUpdateTest
    {
        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int SubObjectId { get; set; }
            public SubObject SubObject { get; set; }
        }
        public class SubObject
        {
            public int Id { get; set; }
            public string Something { get; set; }
        }
        public class CustomerContext : DbContext
        {
            public DbSet<Customer> Customers { get; set; }
            public DbSet<SubObject> SubObjects { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                int customerId = 0;
                int subObject1Id = 0;
                int subObject2Id = 0;
                using (var ctx = new CustomerContext())
                {
                    // Create customer with subobject
                    var customer = new Customer { Name = "John" };
                    var subObject = new SubObject { Something = "SubObject 1" };
                    customer.SubObject = subObject;
                    ctx.Customers.Add(customer);
                    // Create a second subobject, not related to any customer
                    var subObject2 = new SubObject { Something = "SubObject 2" };
                    ctx.SubObjects.Add(subObject2);
                    ctx.SaveChanges();
                    customerId = customer.Id;
                    subObject1Id = subObject.Id;
                    subObject2Id = subObject2.Id;
                }
                // New context, simulate detached scenario -> MVC action
                using (var ctx = new CustomerContext())
                {
                    // Changed customer name
                    var customer = new Customer { Id = customerId, Name = "Jim" };
                    ctx.Customers.Attach(customer);
                    // Changed reference to another subobject
                    var subObject2 = ctx.SubObjects.Find(subObject2Id);
                    customer.SubObject = subObject2;
                    ctx.Entry(customer).State = EntityState.Modified;
                    ctx.SaveChanges();
                    // No exception here.
                }
            }
        }
    }
