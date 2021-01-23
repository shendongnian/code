    public interface IInvoice
    {
        double? Amount { get; set; }
    }
    public interface ITransaction
    {
        double? SubTotal { get; set; }
    }
