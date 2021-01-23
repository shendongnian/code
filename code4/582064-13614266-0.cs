    public interface ICustomer
    {
       string FirstName { get; }
       string LastName  { get; }
    }
    public class Customer : ICustomer
    {
       public string FirstName { get; internal set; }
       public string LastName  { get; internal set; }
    }
