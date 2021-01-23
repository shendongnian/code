    public List<Tuple<int,YourObject>> MyItems {get;set;} //INotifyPropertyChanged or ObservableCollection
    public void PopulateItems(List<YourObject> items)
    {
         MyItems = items.Select(x => new Tuple<int,YourObject>(items.IndexOf(x),x)).ToList();
    }
    <ComboBox ItemsSource="{Binding MyItems}" DisplayMemberPath="Item1"/>
