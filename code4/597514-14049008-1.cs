    public partial class MainWindow : Window
    {
        History use1 = new History();
        Precaution use2 = new Precaution();
        Uses use3 = new Uses();
        SideEffect use4 = new SideEffect();
        NewItem use5 = new NewItem();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Container.Child = use1;
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Container.Child = use2;
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Container.Child = use3;
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Container.Child = use4;
        }
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Container.Child = use5;
        }
    }
