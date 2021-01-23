    public class NewsViewModel
    {
        public string SelectedCategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        ... put any properties that your view might require
    }
