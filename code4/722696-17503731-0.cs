    public class CustomerRegistry : ICustomerEx {
        // singelton
        public static final CustomerRegistry theRegistry = new CustomerRegistry();
        private ArrayList<ICustomerEx> customers = new ArrayList<ICustomerEx>();
        public void RegisterCustomer(ICustomerEx customer) {
           customers.add(customer);
        }
        public void Load(DataRow row)
        {
           foreach(ICustomerEx customer in customers) {
              customer.Load(row);
           }
        }
    } 
