    var myScrollviewer = VisualTreeHelper.GetChild(MyListBox, 0) as ScrollViewer;
    myScrollviewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
    myScrollviewer.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
    //key part - use SetValue to set ManipluationMode.System/Control
    myScrollviewer.SetValue(ScrollViewer.ManipulationModeProperty, ManipulationMode.Control);
