    public interface ICustomer
    {
        string FirstName { get; }
        string SecondName { get; }
    }
    internal interface ICustomerWithSetMethods : ICustomer
    {
        void SetFirstName(string name);
        void SetLastName(string name);
    }
    public class Customer : ICustomerWithSetMethods
