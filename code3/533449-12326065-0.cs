    class Program
    {
        static void Main(string[] args)
        {
            var transaction = new Transaction();
            var transactionAmount = transaction.Amount;
            var invoice = new Invoice();
            var invoiceSubTotal = invoice.SubTotal;
            Transaction fromInvoiceToTrans = invoice;
            var fromInvoiceToTransAmount = fromInvoiceToTrans.Amount;
        }
    }
    public class Transaction
    {
        public decimal Amount {get; set;}
    }
    public class Invoice
    {
        public decimal SubTotal
        {
            get;
            set;
        }
        public static implicit operator Transaction(Invoice invoice)
        {
            return new Transaction
            {
                Amount = invoice.SubTotal
            };
        }
    }
