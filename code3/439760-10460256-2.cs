        public ClassConstructor()
        {
            InitializeComponent();
            OriginalGrid.SelectionChanged -= OriginalGrid_SelectionChanged;
            OriginalGrid.SelectionChanged += OriginalGrid_SelectionChanged;
        }
        private void OriginalGrid_SelectionChanged(object sender, 
            SelectionChangedEventArgs e)
        {
            SelectedGridRows.ItemsSource = OriginalGrid.SelectedItems;
        }
