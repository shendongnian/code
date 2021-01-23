    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
    
        public bool myProperty
        {
            get { return (bool)GetValue(myPropertyProperty); }
            set { SetValue(myPropertyProperty, value); }
        }
    
        // Using a DependencyProperty as the backing store for myProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty myPropertyProperty =
            DependencyProperty.Register("myProperty", typeof(bool), typeof(MainWindow), new UIPropertyMetadata(false));
    
    
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            myProperty = !myProperty;
        }
    }
