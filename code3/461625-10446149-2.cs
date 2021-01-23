    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Button btn = new Button();
                btn.Content = "Moo";
                stackPanel1.Children.Add(btn);
                Button btn2 = new Button();
                btn2.Content = "test";
                stackPanel1.Children.Add(btn2);
    
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
            }
        }
    }
