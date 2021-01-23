    public class CustomerRepository
    {
        public Customer GetCustomerWithName(string name);
    }
    
    public class SupplierRepository
    {
        public IEnumerable<Supplier> GetSuppliersWhoStockItem(string itemName)
    }
