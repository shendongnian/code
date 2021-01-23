    public class CsvResult : ExportAccountsResult
    {
        public CsvResult(IEnumerable<Account> accounts, ExportViewModel exportOptions)
            : base(accounts, exportOptions)
        {
        }
        protected override string ContentType
        {
            get { return "text/csv"; }
        }
        protected override string Filename
        {
            get { return "accounts.csv"; }
        }
    }
    public class XlsResult : ExportAccountsResult
    {
        public XlsResult(IEnumerable<Account> accounts, ExportViewModel exportOptions)
            : base(accounts, exportOptions)
        {
        }
        protected override string ContentType
        {
            get { return "application/vnd.ms-excel"; }
        }
        protected override string Filename
        {
            get { return "accounts.csv"; }
        }
    }
