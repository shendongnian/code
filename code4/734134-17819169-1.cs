    public class SubscriptionEditViewModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public IEnumerable<CompanySelectViewModel> Companies { get; set; }
    }
