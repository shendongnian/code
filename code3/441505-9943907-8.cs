    public class NHibernateInvoiceQuery : IInvoiceQuery
    {
        IQueryable<Invoice> _query;
        public NHibernateInvoiceQuery(ISession session)
        {
            _query = session.Query<Invoice>();
        }
        public IInvoiceQuery Started()
        {
            _query = _query.Where(x => x.IsStarted);
            return this;
        }
        public IInvoiceQuery WithoutError()
        {
            _query = _query.Where(x => !x.HasError);
            return this;
        }
        public Invoice ByInvoiceNumber(string invoiceNumber)
        {
            return _query.SingleOrDefault(x => x.InvoiceNumber == invoiceNumber);
        }
        public IEnumerator<Invoice> GetEnumerator()
        {
            return _query.GetEnumerator();
        }
        
        // ...
    } 
