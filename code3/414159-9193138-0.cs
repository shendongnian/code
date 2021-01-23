    public interface ICustomerInfo
    {
        string ReturnCustomerName();
    }
    
    [DataContract(Name = "Customer")]
    public class CustomerTypeA : ICustomerInfo
    {
        public string ReturnCustomerName()
        {
            return "no name";
        }
    }
    
    [DataContract(Name = "Customer")]
    public class CustomerTypeB : ICustomerInfo
    {
        public string ReturnCustomerName()
        {
            return "no name";
        }
    }
    
    [DataContract]
    [KnownType(typeof(CustomerTypeB))]
    public class PurchaseOrder
    {
        [DataMember]
        ICustomerInfo buyer;
    
        [DataMember]
        int amount;
    }
