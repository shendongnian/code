    private static void OnContainerPreviewDragOver(object sender, DragEventArgs e)
    {
        FrameworkElement container = sender as FrameworkElement;
 
        if (container == null) { return; }
 
        ScrollViewer scrollViewer = GetFirstVisualChild<ScrollViewer>(container);
 
        if (scrollViewer == null) { return; }
 
        double tolerance = 60;
        double verticalPos = e.GetPosition(container).Y;
        double offset = 20;
 
        if (verticalPos < tolerance) // Top of visible list? 
        {
            //Scroll up
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - offset);
        }
        else if (verticalPos > container.ActualHeight - tolerance) //Bottom of visible list? 
        {
            //Scroll down
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + offset);     
        }
    }
