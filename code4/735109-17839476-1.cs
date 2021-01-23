    namespace WpfApplication11
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var form1 = new Form1();
                form1.ShowDialog();
                Close();
            }
        }
    }
