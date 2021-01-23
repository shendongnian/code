     namespace WpfApplication1
        {
            /// <summary>
            /// Interaction logic for MainWindow.xaml
            /// </summary>
            /// 
        
            public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    InitializeComponent();
                    Customer Data1 = new Customer("Joint1", "Action1");
                    List<Customer> list = new List<Customer>();
                    list.add(Data1);
                    dataGrid1.ItemsSource = list;
        
                }
            }
        }
