    public interface IRepository
    {
        IQueries Queries { get; }
    }
    public interface IQueries
    {
        IInvoiceQuery Invoices { get; }
        IUserQuery Users { get; }
    }
    public interface IInvoiceQuery : IQuery<Invoice>
    {
        IInvoiceQuery Started();
        IInvoiceQuery Unfinished();
        IInvoiceQuery WithoutError();
        Invoice ByInvoiceNumber(string invoiceNumber);
    }
