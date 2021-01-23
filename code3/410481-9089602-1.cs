    // Create an instance of your context
    var myContext = new MyContext();
    myContext.Values = new ObservableCollection<string>();
    // Set up a binding between your collection and the 'Items' property of the listbox
    Binding b = new Binding();
    b.Source = myContext;
    b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    b.Path = new PropertyPath("Values");
    ListBox1.SetBinding(ListBox.ItemsSourceProperty, b);
    // Add values to the collection - these will automatically end up in the listbox
    myContext.Values.Add("New item");
    myContext.Values.Add("Other new item");
    // You can change values too
    myContext.Values[0] = "This has changed";
