    public class MyViewModel
    {
        public IEnumerable<string> Columns { get; set; }
        public IEnumerable<dynamic> Values { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
        public IEnumerable<CustomerModel> Customers { get; set; }
        public IEnumerable<SelectListItem> Jobs { get; set; }
        
        public CustomerModel Customer {get; set;}
    }
