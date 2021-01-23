        public MainWindow()
        {
            InitializeComponent();
            // Collection which will take your Filter
            var _itemSourceList = new CollectionViewSource() { Source = ObColl };
           //now we add our Filter
           _itemSourceList.Filter += new FilterEventHandler(yourFilter);
            // ICollectionView the View/UI part 
            ICollectionView Itemlist = _itemSourceList.View;
            dataGrid1.ItemsSource = Itemlist;
        }
        private void yourFilter(object sender, FilterEventArgs e)
        {
            var obj = e.Item as Model;
            if (obj != null)
            {
                if (obj.Name.Contains("Max"))
                    e.Accepted = true;
                else
                    e.Accepted = false;
            }
        }
