    public class CustomerRepository
    {
       public List<Customer> GetAllCustomers()
       {
           using (var context = new MyEntities() )            
               return context.Customers.ToList();
       }
    }
