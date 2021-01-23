    private void addstackrows()
    {
        Dispatcher stackpaneldispatcher = stackPanel1.Dispatcher;
        stackPanel1.Dispatcher.Invoke(new Action(() =>
        {
            stackPanel1.Children.Clear();
            stackPanel1.Orientation = Orientation.Vertical;
        }));
        foreach (var randomelement in elementcollection)
        {
            stackPanel1.Dispatcher.Invoke(new Action(() =>
            {
                StackPanel stackrow = new StackPanel();
                stackrow.Orientation = Orientation.Horizontal;
                stackPanel1.Children.Add(stackrow);
            }));
        }
    }
