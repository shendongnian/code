    ListBox listBox1 = new ListBox();
    listBox1.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty,
    ScrollBarVisibility.Disabled);
    listBox1.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, 
    ScrollBarVisibility.Disabled);
    listBox1.SetValue(ScrollViewer.CanContentScrollProperty, false);
    
    listBox1.SetValue(ScrollViewer.IsDeferredScrollingEnabledProperty, true);
