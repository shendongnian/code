        public ClassConstructor()
        {
            InitializeComponent();
            SelectedGridRows.SelectionChanged -= SelectedGridRows_SelectionChanged;
            SelectedGridRows.SelectionChanged += SelectedGridRows_SelectionChanged;
        }
        private void SelectedGridRows_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedGridRows.ItemsSource = ui_dtgAgreementDocuments.SelectedItems;
        }
