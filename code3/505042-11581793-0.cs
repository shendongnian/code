    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            WpfApplication2.MainWindow newForm;
            public MainWindow()
            {
                InitializeComponent();
            
            }
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                newForm = new WpfApplication2.MainWindow();
                newForm.Show();  // or newForm.ShowDialog();
            }
        }
    }
