    public interface IReadCustomer
    {
        string FirstName { get; }
        string LastName { get; }
    }
    
    internal interface IWriteCustomer
    {
        string FirstName { set; }
        string LastName { set; }
    }
    
    internal interface IReadWriteCustomer : IReadCustomer, IWriteCustomer
    { }
    
    public class Customer : IReadWriteCustomer
    {
        private string _firstName;
        private string _lastName;
    
        public string FirstName
        {
            get { return _firstName; }
            internal set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            internal set { _lastName = value; }
        }
    
        string IReadCustomer.FirstName
        {
            get { return FirstName; }
        }
    
        string IReadCustomer.LastName
        {
            get { return LastName; }
        }
    
        string IWriteCustomer.FirstName
        {
            set { FirstName = value; }
        }
    
        string IWriteCustomer.LastName
        {
            set { LastName = value; }
        }
    }
