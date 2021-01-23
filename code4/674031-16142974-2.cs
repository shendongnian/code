    public class Customer : Entity<Customer>
    {
    }
    public abstract class Entity<T> 
        where T : Entity<T>
    {
        public T Clone(T entityToClone)
        {
            return default(T); // Clone code here, returns derived type.
        }
    }   
    
    // Grants you...
    Customer clonedCustomer = currentCustomer.Clone();
    // Instead of...
    Customer clonedCustomer = (Customer)currentCustomer.Clone();
    // Ignore ethical constraints on cloning customers and definitely do not tell your sales team that you can ;-)
