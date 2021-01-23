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
            private void bla1_changeHaus(object sender, RoutedEventArgs e)
            {
                bla2.SetHaus();
            }
            private void bla1_changeSoccer(object sender, RoutedEventArgs e)
            {
                bla2.SetSoccer();
            }
            private void bla2_changeHaus(object sender, RoutedEventArgs e)
            {
                bla1.SetHaus();
            }
            private void bla2_changeSoccer(object sender, RoutedEventArgs e)
            {
                bla1.SetSoccer();
            }
        }
    }
