    public class Invoice : TransactionBase
    {
        public double SubTotal
        {
            get
            {
                return Amount;
            }
            set
            {
                Amount = value;
            }
        }
    }
