    public class SelectedCustomers
    {
        public IEnumerable<Account> Info { get; set; }
    }
    public class Account
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
    }
    public class ExportViewModel
    {
        public string Format { get; set; }
        public bool IncludeName { get; set; }
        public bool IncludeDescription { get; set; }
        public bool IncludeAddress { get; set; }
    }
