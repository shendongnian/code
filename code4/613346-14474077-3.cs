      /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Order> MyOrders
        {
            get { return _myOrders; }
            set { _myOrders = value; OnPropertyChanged("MyOrders"); }
        }
        Order order1 = new Order
         {
             OrderName = "Order1",
             PartsList = new List<Parts>()
            {
                new Parts {PartName = "Part11", PartQuantity = 11},
                new Parts {PartName = "Part12", PartQuantity = 12}
            }
         };
        private ObservableCollection<Order> _myOrders;
        public MainWindow()
        {
            InitializeComponent();
            MyOrders = new ObservableCollection<Order>();
            MyOrders.Add(order1);
            DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
        public class Order
        {
            public string OrderName { get; set; }
            public List<Parts> PartsList { get; set; }
        }
    
        public class Parts
        {
            public string PartName { get; set; }
            public double PartQuantity { get; set; }
            }
    }
