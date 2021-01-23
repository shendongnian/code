        public MainPage()
        {
            InitializeComponent();
        }
        private void FillGridWithItems()
        {   
            //Row and ColumnDefinitions
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                   var item = new MyStackPanel(children)
                   Grid.SetColumn(item, col);
                   Grid.SetRow(item, row);
                   grid.Children.Add(item);
                }
            }
            Loaded+=PageLoaded;            
        }
        /// When page is loaded, ActualHeight of elements are calculated for sure.
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            foreach (var child in grid.Children)
            {
                var item = child as MyStackPanel;
                if (item != null)
                {
                    item.FillInData();
                }
            }
        }
        /// Used instead of constructor, cause a parameter is sent to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            FillGridWithItems()
        }
