    public class ViewModel
    {
        public ViewModel()
        {
            Products = new ObservableCollection<Product>()
            {
                new Product("book"),
                new Product("chair"),
                new Product("table"),
                new Product("bookshelf"),
            }
        }
        ObservableCollection<Product> Products { get; set; }
    }
