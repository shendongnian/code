    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for Foo.xaml
        /// </summary>
        public partial class Foo : Window
        {
            public Foo()
            {
                InitializeComponent();
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
        }
    }
