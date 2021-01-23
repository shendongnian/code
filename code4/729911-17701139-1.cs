    void Main()    
    {
        var customer = new Customer
          {
            CustomerId = Listbox1.SelectedValue,
            EmailAddress = Listbox2.SelectedValue
          };
    	
        UpdateEmailAddress(customer);
        //OR
        AddCustomer(customer);
    
    }
    
    public void AddCustomer(Customer customer)
    {
    	using (var db = new DatabaseEntities())
    	{
    		db.Customers.Add(customer);
    		db.SaveChanges();
    	}
    }
    
    public void UpdateEmailAddress(Customer customer)
    {
        using (var db = new DatabaseEntities())
        {
           var selectedCustomer = db.Customers.Where(x=>x.CustomerId==customer.CustomerId).Select(x=x);
           selectedCustomer.EmailAddress = customer.EmailAddress;
           db.SaveChanges();
        }
    }
    
    public class Customer
    {
        public int CustomerId {get;set;}
        public string EmailAddress {get;set;}
    }
