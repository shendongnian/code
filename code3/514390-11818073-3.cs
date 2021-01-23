    public class MyViewModel
    {
        [DisplayName("Company")]
        public int CompanyId { get; set; }
        public IEnumerable<SelectListItem> Companies { get; set; }
    }
