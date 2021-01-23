    void Main_Loaded(object sender, RoutedEventArgs e)
    {
        var mdiChild = new MdiChild
        {
            Title = "Window Using Code",
            Content = new ExampleControl(),
            Width = 500,
            Height = 450,
            Position = new Point(200, 30)
        };
        Container.Children.Add(mdiChild);
        mdiChild.Loaded +=new RoutedEventHandler(mdiChild_Loaded);
    }
    void mdiChild_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender is MdiChild)
        {
            var mdiChild = (sender as MdiChild);
            mdiChild.WindowState = WindowState.Maximized;
        }
    }
