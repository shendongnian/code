    var listViewCollection1 = (ListCollectionView)CollectionViewSource.GetDefaultView(Items);
    listViewCollection1.Filter = item => (item as string).Length == 5;
    listView1.ItemsSource = listViewCollection1;
    var newView = new CollectionViewSource() { Source = Items };
    var listViewCollection2 = (ListCollectionView)newView;
    listViewCollection2.Filter = item => (item as string).Length == 3;
    listView2.ItemsSource = listViewCollection2;
