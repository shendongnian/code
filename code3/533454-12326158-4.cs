    public class Transaction : TransactionBase
    {
        public new double Amount 
        { 
            get
            {
                return base.Amount;
            }
            set
            {
                base.Amount = value;
            }
        }
    }
