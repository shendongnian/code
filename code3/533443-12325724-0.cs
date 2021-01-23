    public class Transaction
    {
        public double Amount { get; set; }
    }
    public interface IInvoice
    {
        public double? SubTotal { get; set; }
    }
    public class Invoice : Transaction, IInvoice
    {
        public double? SubTotal
        {
            get
            {
                return Amount;
            }
            set
            {
                Amount = value ?? 0.0f;
            }
        }
    }
