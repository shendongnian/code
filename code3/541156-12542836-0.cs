    public partial class MainWindow : Window
    {
        private ObservableCollection<string> ListItems = new ObservableCollection<string>  
        { 
            "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6"
        };
        public MainWindow()
        {
            InitializeComponent();
            lbItems.ItemsSource = this.ListItems;
        }
        private void up_click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = this.lbItems.SelectedIndex;
            if (selectedIndex > 0)
            {
                var itemToMoveUp = this.ListItems[selectedIndex];
                this.ListItems.RemoveAt(selectedIndex);
                this.ListItems.Insert(selectedIndex - 1, itemToMoveUp);
                this.lbItems.SelectedIndex = selectedIndex - 1;
            }
        }
        private void down_click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = this.lbItems.SelectedIndex;
            if (selectedIndex + 1 < this.ListItems.Count)
            {
                var itemToMoveDown = this.ListItems[selectedIndex];
                this.ListItems.RemoveAt(selectedIndex);
                this.ListItems.Insert(selectedIndex + 1, itemToMoveDown);
                this.lbItems.SelectedIndex = selectedIndex + 1;
            }
        }
    }
