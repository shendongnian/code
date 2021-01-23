    using System.Collections.ObjectModel;
    
    namespace GridAutoWidth
    {
        class MainViewModel
        {
            public MainViewModel()
            {
                for (int i = 0; i < 10; i++)
                {
                    Products.Add(new Product 
                    {
                        Name = "Name " + i,
                        Price = (decimal)(18 * (i + 8.4)),
                        Code = "Sample code " + i
                    });
                }
            }
    
            private ObservableCollection<Product> _products = new ObservableCollection<Product>();
    
            public ObservableCollection<Product> Products
            {
                get { return _products; }
                set { _products = value; }
            }
        }
    
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Code { get; set; }
        }
    }
