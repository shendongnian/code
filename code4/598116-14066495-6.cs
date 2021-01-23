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
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                TextBlock block = new TextBlock();
                block.Width = 250;
                block.Height = 100;
                block.Text = "Hello World"; // Notepad.Text;
                block.Foreground = new SolidColorBrush(Colors.Blue);
                gridName.Children.Add(block);
                Grid.SetColumn(block, 0);  /Not neccesary since not multiple columns
                Grid.SetRow(block, 0);
            }
        }
    }
