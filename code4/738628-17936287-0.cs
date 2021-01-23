    var myScrollviewer = VisualTreeHelper.GetChild(MyListBox, 0) as ScrollViewer;
    myScrollviewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
    myScrollviewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
    //key part - use SetValue to set ManipluationMode.System/Control
    myScrollviewer.SetValue(ScrollViewer.ManipulationModeProperty, ManipulationMode.System);
