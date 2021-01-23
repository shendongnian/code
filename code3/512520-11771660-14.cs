    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) => 
            { 
                tbText.Focus(); 
                tbText.CaretIndex = tbText.Text.Length; 
            };
        }
        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbText.Text))
            {
                tbText.Text = tbText.Text.Substring(0, tbText.Text.Length - 1);
                tbText.CaretIndex = tbText.Text.Length;
            }
        }
    }
