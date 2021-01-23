    public class MyViewModel
    {
        public int? SelectedCustomerId { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        public int? SelectedJobId { get; set; }
        public IEnumerable<SelectListItem> Jobs { get; set; }
        public IEnumerable<string> Columns { get; set; }
        public IEnumerable<object> Values { get; set; }
    }
