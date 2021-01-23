    public partial class MainWindow : Window
    {
        TextBox LastFocusedTextBox;
        public MainWindow()
        {
            this.InitializeComponent();
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            InsertButtonContent((Button)sender);
        }
        private void txt_diplay_GotFocus(object sender, RoutedEventArgs e)
        {
            LastFocusedTextBox = (TextBox)sender;
        }
        public void InsertButtonContent(Button button)
        {
            if (LastFocusedTextBox != null)
            {
                string buttonContentString = button.Content as string;
                if (string.IsNullOrEmpty(buttonContentString))
                {
                    var grid = button.Content as Grid;
                    if (grid != null)
                        buttonContentString = string.Join("", grid.Children.OfType<ContentControl>().Select(x => x.Content));
                }
                var caret_index = LastFocusedTextBox.CaretIndex;
                LastFocusedTextBox.Text = LastFocusedTextBox.Text.Insert(caret_index, buttonContentString);
                LastFocusedTextBox.Focus();
                LastFocusedTextBox.CaretIndex = caret_index + buttonContentString.Length;
            }
        }
    }
