    <ListBox ItemsSource="{Binding Foo}"/>
    
    private ObservableCollection<RegButtton> RegBtns = new...;
    
    public ICollectionView Foo { get; set; }
    
    Foo = CollectionViewSource.GetDefaultView(RegBtns);
    Foo.SortDescriptions.Add(new SortDescription("SomePropertyName", ListSortDirection.Ascending));
    Foo.Refresh();
