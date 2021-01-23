    MenuItem mnuItemDepth = new MenuItem();
    foreach (ClassDepth depth in ClassDepths.ListOfDepths)
    {
        var tempDepth = depth;  //capture the loop variable here
        MenuItem it = new MenuItem();
        it.Header = depth.name;
        it.Click += new RoutedEventHandler((s, a) => { ChangeDepth(tempDepth); });
        mnuItemDepths.Items.Add(it);
    }
