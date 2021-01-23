    public abstract class TransactionBase
    {
        // There are some shared properties here.
    }
    
    public class Transaction : TransactionBase
    {
        public double Amount { get; set; }
    }
    
    public class Invoice : TransactionBase
    {
        public double SubTotal { get; set; }
    }
