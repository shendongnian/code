    public class PaymentDetails
    {
        public int Id { get; internal set; }
        public string Status { get; internal set; } 
    }
    
    public class PaymentHelper
    {
        public PaymentDetails Details { get; private set; } 
    }
