    public enum CustomerStatus
    {
        Active,
        Inactive,
        Deleted
    }
    public class Customer
    {
        public CustomerStatus Status { get; set; }
    }
