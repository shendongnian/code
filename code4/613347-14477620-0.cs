    public partial class MainWindow : Window
    {
        public List<Order> myOrders { get; set; }
        Order order1 = new Order
        {
            OrderName = "Order1",
            PartsList = new List<Parts>()
            {
                  new Parts {PartName = "Part11", PartQuantity = 11},
                  new Parts {PartName = "Part12", PartQuantity = 12}
             }
         };
        Order order2 = new Order
        {
            OrderName = "Order2",
            PartsList = new List<Parts>()
            {
                  new Parts {PartName = "Part21", PartQuantity = 21},
                  new Parts {PartName = "Part22", PartQuantity = 22},
                  new Parts {PartName = "Part23", PartQuantity = 23}
             }
         };
    
         public MainWindow()
            {
                InitializeComponent();
                myOrders = new List<Order>();
                myOrders.Add(order1);
                myOrders.Add(order2);
                DataContext = this;
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
