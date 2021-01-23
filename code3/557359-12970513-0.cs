    public class MyViewModel
    {
        public string From { get; set; }
        public IEnumerable<SelectListItem> FromValues { get; set; }
    
        public string To { get; set; }
        public IEnumerable<SelectListItem> ToValues { get; set; }
    }
