    public partial class MainWindow : Window
    {
        List<String> items;
        public MainWindow()
        {
            InitializeComponent();
            items = new List<String>(); 
            // Fill your list with whatever items you need
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            items.Sort();
            listBox.Items.Clear();
            foreach (String str in items)
            {
                listBox.Items.Add(str);
            }
            MessageBox.Show("Done");
        }
    }
