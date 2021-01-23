    public class Payment {}
    
    public class VoucherPayment : Payment {}
    
    public class MoneyPayment : Payment
    {
        public PaymentMode { get; set; }
    }
    
    public enum PaymentMode 
    {
        Cash,
        CreditCard
    }
