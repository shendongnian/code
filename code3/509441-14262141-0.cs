    public MainWindow()
        {
            InitializeComponent();
            this.comboBox1.Loaded += new RoutedEventHandler(ComboBoxLoaded);           
        }
        private void ComboBoxLoaded(object sender, RoutedEventArgs e)
        {
            ListCollectionView view = (ListCollectionView)CollectionViewSource.GetDefaultView(((XmlDataProvider)this.myGrid.DataContext).Data);
            view.SortDescriptions.Add(new SortDescription("Location", ListSortDirection.Ascending));
        }    
