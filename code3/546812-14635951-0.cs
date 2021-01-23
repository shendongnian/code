    public partial class MainWindow : Window
    {
        ViewModel vm = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            vm.Products = new ObservableCollection<Product>
            {
                new Product { Name = "Product1", LineTotal = 10 },
                new Product { Name = "Product2", LineTotal = 20 },
                new Product { Name = "Product3", LineTotal = 15 }
            };
            this.DataContext = vm;
        }
        private void AddItem(object sender, RoutedEventArgs e)
        {
            vm.Products.Add(new Product { Name = "Added product", LineTotal = 50 });
        }
        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            vm.Products.RemoveAt(0);
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                // We need to know when the ObservableCollection has changed.
                // On added products: hook up eventhandlers to their PropertyChanged events.
                // On removed products: recalculate the total.
                _products.CollectionChanged += (sender, e) =>
                {
                    if (e.NewItems != null)
                        AttachProductChangedEventHandler(e.NewItems.Cast<Product>());
                    else if (e.OldItems != null)
                        CalculateTotalAmount();
                };
                AttachProductChangedEventHandler(_products);
            }
        }
        private void AttachProductChangedEventHandler(IEnumerable<Product> products)
        {
            // Attach eventhandler for each products PropertyChanged event.
            // When the LineTotal property has changed, recalculate the total.
            foreach (var p in products)
            {
                p.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == "LineTotal")
                        CalculateTotalAmount();
                };
            }
                
            CalculateTotalAmount();
        }
        public void CalculateTotalAmount()
        {
            // Set TotalAmount property to the sum of all line totals.
            TotalAmount = Products.Sum(p => p.LineTotal);
        }
        private decimal _TotalAmount;
        public decimal TotalAmount
        {
            get { return _TotalAmount; }
            set
            {
                if (value != _TotalAmount)
                {
                    _TotalAmount = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("TotalAmount"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Product : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private decimal _LineTotal;
        public decimal LineTotal
        {
            get { return _LineTotal; }
            set
            {
                if (value != _LineTotal)
                {
                    _LineTotal = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("LineTotal"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
