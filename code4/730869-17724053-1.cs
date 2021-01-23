    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("some button");
        }
    
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("button1");
        }
    
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("button2");
        }
    }
