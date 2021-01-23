    // in the library:
    public static class CustomerFactory {
       private static volatile Func<ICustomerEx> instance = () => new Customer(); 
       public static Func<ICustomerEx> Instance { get { return instance; } set { instance = value; } }        
    }
    // then to get a customer
    var cust = CustomerFactor.Instance();
    cust.Load(row);
    // in the UI code:
    CustomerFactory.Instance = () => new UiCustomer();
