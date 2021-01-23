    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var bindingExpression = Text1.GetBindingExpression(TextBox.TextProperty);
            bindingExpression.UpdateSource();
        }
    }
