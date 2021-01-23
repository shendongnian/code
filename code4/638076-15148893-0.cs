    public partial class VerifyWindow : Window
    {
        public VerifyWindow(string content)
        {
            InitializeComponent();
            TBText = content;
        }
        public static readonly DependencyProperty TBTextProperty =
            DependencyProperty.Register("TBText", typeof(string), typeof(VerifyWindow), new UIPropertyMetadata(string.Empty));
        public string TBText
        {
            get { return (string)GetValue(TBTextProperty); }
            set { SetValue(TBTextProperty, value); }
        }
        private void CancelVerify(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        private void ConfirmVerify(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
