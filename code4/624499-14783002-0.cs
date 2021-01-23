    [DataContract]  
    public class CustomerStatuses
    {
      [DataMember(Name = "CustomerStatuses")]
      public IEnumerate<Customer> Customers;
    }
    
    [DataContract]
    public class Customer
    {
      [DataMember(Name = "Status")]
      public int Status;
      
      [DataMember(Name = "CustomerId")]
      public String Guid;
    
      [DataMember(Name = "Information")]
      public Object Info;
    }
