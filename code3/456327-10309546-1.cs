    using System.Windows;
    
    namespace CheckRichTextBox
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
    
            private void BtnAddClick(object sender, RoutedEventArgs e)
            {
                richTextBox1.AppendText("You had Clicked the button for adding text\n");
                richTextBox1.ScrollToEnd();
            }
        }
    }
