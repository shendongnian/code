    public class Transaction : ITransaction
    {
        public double? SubTotal { get; set; }
    }
    public class Invoice : IInvoice
    {
        public double? Amount
        {
            get { return base.SubTotal; }
            set { base.SubTotal = value; }
        }
    }
