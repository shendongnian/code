        private ObservableCollection<string> _fruits;
        private ObservableCollection<string> _fruitsSelected;
    
        public IEnumerable<string> GetFruits()
        {
            _fruits = new ObservableCollection<string> 
                                {
                                    "Apples",
                                    "Bananas",
                                    "Oranges",
                                    "Grapes",
                                    "Coconut"
                                };
    
            return _fruits;
        } 
    public GroceriesList()
        {
            InitializeComponent();
            _fruitsSelected = new ObservableCollection<string>();
            ListBox1.ItemsSource = _shopping.GetFruits();
            ListBox2.ItemsSource = _fruitsSelected;
    
        }
    
      private void ListBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBox1.SelectedItem != null)
            {
                _fruitsSelected.Add(ListBox1.SelectedItem);
                _fruits.Remove(ListBox1.SelectedItem);
            }
        }
