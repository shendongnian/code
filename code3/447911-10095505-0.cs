    void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        //Xceed DataGridCollectionView are terrible and do not update when the bound table changes, so we need to replace them each change.
       if (e.PropertyName == "MyCollection")
       {
           DataGridCollectionView GridView = new DataGridCollectionView(MyViewModel.MyCollection.DefaultView);
           GridView.SortDescriptions.Add(new SortDescription("DataSetID", ListSortDirection.Ascending));
           uiMyCollectionGrid.ItemsSource = GridView;
       }
    }
