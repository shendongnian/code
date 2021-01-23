    //All customers will implement this.
    public interface ICustomer
    {
        string GenerateReferenceNumber();
    }
    
    public class CustomerOne : ICustomer
    {
        public string GenerateReferenceNumber()
        {
            return "Reference Implemenation 1";
        }
    }
    
    public class CustomerTwo : ICustomer
    {
        public string GenerateReferenceNumber()
        {
            return "Reference Implemenation 2";
        }
    } 
    
    
    Dictionary<string,ICustomer> customers = new Dictionary<string,ICustomer>();
    
    customers.Add("CustomerOne",new CustomerOne());
    customers.Add("CustomerTwo",new CustomerTwo());
    
    var customerOne = customers["CustomerOne"];
    var customerTwo = customers["CustomerTwo"];
    
    Console.WriteLine(customerOne.GenerateReferenceNumber());
    Console.WriteLine(customerTwo.GenerateReferenceNumber());
