    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    
    namespace WpfLab
    {
        public partial class MainWindow : Window
        {
            Product selectProduct;
            
            public MainWindow()
            {
                InitializeComponent();
    
                Products = new ObservableCollection<Product>();
                ProductTabs = new ObservableCollection<Product>();
    
                var products = Enumerable.Range(0, 10).Select(i => new Product { Header = "Product " + i });
                foreach (var p in products)
                    Products.Add(p);
    
                DataContext = this;
            }
    
            public Product SelectedProduct 
            {
                get { return this.selectProduct; }
                
                set
                {
                    UpdateTabs(this.selectProduct, value);
                    this.selectProduct = value;
                }
            }
    
            public ObservableCollection<Product> Products { get; private set; }
    
            public ObservableCollection<Product> ProductTabs { get; private set; }
    
            void UpdateTabs(Product old, Product @new)
            {
                if (ProductTabs.Any(p => p == old))
                    ProductTabs.Remove(old);
                
                ProductTabs.Add(@new);
            }
        }
    
        public class Product
        {
            public string Header { get; set; }
    
            public override string ToString()
            {
                return Header;
            }
        }
    }
     
