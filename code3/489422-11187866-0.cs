    listView.ItemsSource = from i in Enumerable.Range(0, 100) select "Item" + i.ToString();
    listView.Loaded += (sender, e) =>
    {
        ScrollViewer scrollViewer = listView.GetVisualChild<ScrollViewer>(); //Extension method
        if (scrollViewer != null)
        {
            ScrollBar scrollBar = scrollViewer.Template.FindName("PART_VerticalScrollBar", scrollViewer) as ScrollBar;
            if (scrollBar != null)
            {
                scrollBar.ValueChanged += delegate
                {
                    //VerticalOffset and ViweportHeight is actually what you want if UI virtualization is turned on.
                    Console.WriteLine("Visible Item Start Index:{0}", scrollViewer.VerticalOffset);
                    Console.WriteLine("Visible Item Count:{0}", scrollViewer.ViewportHeight);
                };
            }
        }
    };
