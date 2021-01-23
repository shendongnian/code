    class Program
    {
        static void Main(string[] args)
        {
            var customerEntry = ManageableEntryDaoFactory.CreateDao("customer");
            var orderEntry = ManageableEntryDaoFactory.CreateDao("order");
            customerEntry.Update(new Customer() { Name = "John Doe" });
            orderEntry.Update(new Order() { OrderId = 123 });
            Console.ReadKey();
        }
    }
    public class Customer
    {
        public string Name { get; set; }
    }
    public class Order
    {
        public int OrderId { get; set; }
    }
    public class CustomerEntry : IManageableEntryDao
    {
        public void Update(object objCustomer)
        {
            var customer = objCustomer as Customer;  // now you have a Customer type...
            Console.WriteLine("Updated customer: " + customer.Name);
        }
    }
    public class OrderEntry : IManageableEntryDao
    {
        public void Update(object objOrder)
        {
            var order = objOrder as Order; // now you have an Order type... 
            Console.WriteLine("Updated order: " + order.OrderId);
        }
    }
    public interface IManageableEntryDao
    {
        void Update(object entry);
        // ...other methods, properties, events...
    }
    public static class ManageableEntryDaoFactory
    {
        private static readonly Dictionary<string, Type> daoTypes = new Dictionary<string, Type>() 
        {
            {"customer", typeof(CustomerEntry) }, 
            {"order", typeof(OrderEntry) }
        };
        public static IManageableEntryDao CreateDao(string manageableEntryType)
        {
            manageableEntryType = manageableEntryType.ToLower();
            Type type = daoTypes[manageableEntryType];
            if (type == null)
                throw new NotImplementedException("Failed to find DAO for type: " + manageableEntryType);
            return Activator.CreateInstance(type) as IManageableEntryDao;
        }
    }
