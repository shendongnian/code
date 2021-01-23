    class Form1
      : Form
    {
      private CustomerManager manager;
      
      public Form1()
      {
        ...
    
        manager = new CustomerManager();
        manager.CustomerAdded += OnCustomerAdded;
    
        ...
      }
    
      private void OnCustomerAdded(object source, CustomerEventArgs eventArgs)
      {
        var listviewitem = new ListViewItem(eventArgs.Customer.FirstName);
        listviewitem.SubItems.Add(eventArgs.Customer.LastName);
        
        this.listView1.Items.Add(listviewitem);
      }
    }
    
    class CustomerEventArgs
      : EventArgs
    {
      public readonly Customer Customer;
    
      public CustomerEventArgs(Customer customer)
      {
        Customer = customer;
      }
    }
    
    class Customer
    {
      public string FirstName{get;set;}
      public string LastName{get;set;}
    }
    
    class CustomerManager
    {
      private List<Customer> list = new List<Customer>();
    
      public event EventHandler<CustomerEventArgs> CustomerAdded;
      private void OnCustomerAdded(Customer customer)
      {
         var handler = CustomerAdded;
         if(handler != null)
         {
           handler(this, new CustomerEvenetArgs(customer));
         }
      }
    
      public event EventHandler<CustomerEventArgs> CustomerDeleted;
      private void OnCustomerDeleted(Customer customer)
      {
         var handler = CustomerDeleted;
         if(handler != null)
         {
           handler(this, new CustomerEvenetArgs(customer));
         }
      }
    
      public int Count
      {
         get
         {
           return list.Count;
         }
      }
    
      public bool AddCustomer(Customer customer)
      {
        if(list.Any(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName))
        {
          return false;
        }
    
        list.Add(customer);
        OnCustomerAdded(customer);
        return true;
      }
    
      public bool DeleteCustomer(Customer customer)
      {
        var currentCustomer = list.FirstOrDefault(c => c.FirstName == customer.FirstName && c.LastName == customer.LastName);
        if(currentCustomer != null)
        {
           list.Remove(currentCustomer);
           OnCustomerDeleted(currentCustomer);
           return true;
        }
    
        return false;
      }
    }
