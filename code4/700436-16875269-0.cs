    GridMain.Children.Clear();
    CustomerListControl1 c1 = new CustomerListControl1();
    CustomerListControl2 c2 = new CustomerListControl2();
    GridMain.Childern.Add(c1); //if you use grid
    GridMain.Children.Add(c2); //if you use a grid
    GridMain.Children[0].Visibility = Visibility.Collapsed;
    GridMain.Children[1].Visibility = Visibility.Collapsed;
    GridMain.InvalidateVisual();
