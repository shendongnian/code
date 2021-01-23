    public class Customer
    {
        public string Name
        {
            get;
            set;
        }
        public CustomerStatus Status
        {
            get;
            set;
        }
    }
    public enum CustomerStatus
    {
        Pending = 0,
        Active = 1,
        Deleted = 2
    }
    // Create the dictionary based upon the "filters":
    var dictionary = new Dictionary<CustomerStatus, ICollection<Customer>>();
    dictionary.Add(CustomerStatus.Active, new List<Customer>());
    dictionary.Add(CustomerStatus.Deleted, new List<Customer>());
    dictionary.Add(CustomerStatus.Pending, new List<Customer>());
    // Add some customers:
    dictionary[CustomerStatus.Active].Add(new Customer
    {
        Name = "Active 1"
    });
    dictionary[CustomerStatus.Active].Add(new Customer
    {
        Name = "Active 2"
    });
    dictionary[CustomerStatus.Deleted].Add(new Customer
    {
        Name = "Deleted"
    });
    dictionary[CustomerStatus.Pending].Add(new Customer
    {
        Name = "Pending"
    });
    // Enumerate specific filter or all.
    System.Console.WriteLine("Active Customers Only");
    foreach (var customer in dictionary[CustomerStatus.Active])
    {
        System.Console.WriteLine(customer.Name);
    }
    System.Console.WriteLine("---");
    var allCustomers = dictionary.SelectMany(x => x.Value);
    System.Console.WriteLine("All Customers");
    foreach (var customer in allCustomers)
    {
        System.Console.WriteLine(customer.Name);
    }
