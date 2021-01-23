    public class ProductViewModel : ViewModelBase
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<SelectListItem> SelectItems { get; set; }
        public Guid SelectedItem { get; set; }
    }
