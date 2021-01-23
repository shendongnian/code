    ContextMenu menu1 = new ContextMenu();
    MenuItem menu1Item1 = new MenuItem();
    menu1Item1.Header = "Menu 1 Item 1";
    menu1Item1.Click += new RoutedEventHandler(menu1Item1Clicked);
    menu1.Items.Add(mnu1Item1);
    MenuItem menu1Item2 = new MenuItem();
    menu1Item2.Header = "Menu 1 Item 2";
    menu1Item2.Click += new RoutedEventHandler(menu1Item2Clicked);
    menu1.Items.Add(menu1Item2);
    ContextMenu menu2 = new ContextMenu();
    MenuItem menu2Item1 = new MenuItem();
    menu2Item1.Header = "Menu 2 Item 1";
    menu2Item1.Click += new RoutedEventHandler(menu2Item1Clicked);
    menu2.Items.Add(menu2Item1);
    MenuItem menu2Item2 = new MenuItem();
    menu2Item2.Header = "Menu 2 Item 2";
    menu2Item2.Click += new RoutedEventHandler(menu2Item2Clicked);
    menu2.Items.Add(menu2Item2);
    public void menu1Item1Clicked(object sender, EventArgs e)
    {
    }
    etc..
