    var root = new ObservableCollection<MyGroup>();
    myTreeView.ItemsSource = root;
    
    MyGroup g1 = new MyGroup("First");
    MyGroup g2 = new MyGroup("Second");
    MyGroup g3 = new MyGroup("Third");
    MyItem i1 = new MyItem("Item1");
    MyItem i2 = new MyItem("Item2");
    MyItem i3 = new MyItem("Item3");
    
    root.Add(g1);
    root.Add(g2);
    g2.Children.Add(g3);
    g1.Children.Add(i1);
