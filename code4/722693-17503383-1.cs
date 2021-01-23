    public class Customer:ICustomerEx
    {
       public string Name{get;set;}
       public string Address{get;set;}
    
       void Load(DataRow row)
       {
           this.Name = (string)row["name"];
           this.Address = (string)row["address"];
           this.DoMoreLoading(row);
       }
    
       // this method is defined as a no-op in the base class, but it provides an extension point
       // for derived classes that want to load additional properties
       protected virtual void DoMoreLoading(DataRow row) { }
    }
    
    // note that now UiCustomer extends Customer (and thus still implements ICustomerEx
    public class UiCustomer : Customer
    {
       public string Telephone { get; set; }
    
       protected override void DoMoreLoading(DataRow row)
       {
           this.Telephone = (string)row["tele"];
       }
    }
    
    // usage
    var uiCustomer = new UiCustomer();
    uiCustomer.Load(row); // populates name, addr, and telephone
