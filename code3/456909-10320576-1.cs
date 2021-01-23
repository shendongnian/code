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
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                OtherWindow other = new OtherWindow();
                other.Closed += (sender2, e2) =>
                    {
                        label1.Content = other.SomeData;
                    };
    
                //either of the methods below, depending on desired behavior.
                other.Show();
                //other.ShowDialog();
            }
        }
    }
