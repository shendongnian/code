    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox != null)
            {
                textbox.IsReadOnly = false;
            }
        }
        private void TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox != null)
            {
                textbox.IsReadOnly = true;
            }
        }
    }
