    public partial class MainWindow : Window
    {
        public ViewModel ViewModel { get { return this.DataContext as ViewModel; } }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.Items.Insert( 5, new Item() { MyProperty= "NewElement" });
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.ViewModel.Items.RemoveAt(5);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.ViewModel.InitItems(new Random().Next(10,30));
        }
    }
