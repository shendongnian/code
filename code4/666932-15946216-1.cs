    public partial class MainWindow : Window
    {
        List<Item> items = new List<Item>();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
                items.Add(new Item() { Name = Guid.NewGuid().ToString() });
            DGrid.DataContext = items;
        }
        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            var block = sender as TextBlock;
            var item = block.Tag as Item;
            block.Text = items.IndexOf(item).ToString();
        }
    }
    public class Item
    {
        public string Name { get; set; }
    }
