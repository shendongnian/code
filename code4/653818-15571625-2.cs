        public MainWindow()
        {
            InitializeComponent();
            // Collection which will take your ObservableCollection
            var _itemSourceList = new CollectionViewSource() { Source = ObColl };
            
            // ICollectionView the View/UI part 
            ICollectionView Itemlist = _itemSourceList.View;
            // your Filter
            var yourCostumFilter= new Predicate<object>(item => ((Model)item).Name.Contains("Max"));
            //now we add our Filter
            Itemlist.Filter = yourCostumFilter;
            dataGrid1.ItemsSource = Itemlist;
        }
