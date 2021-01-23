    private void initScrollViewerMonitor(object sender, EventArgs e)
        {   
                //Not the prettiest way to get the scrollviewer out of the listbox    
                Grid test = new Grid();
                var grid = VisualTreeHelper.GetChild(lstEventHistory, 0);
                var border = VisualTreeHelper.GetChild(grid, 0);
                scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                //attach to custom binding to check if ScrollViewer verticalOffset property has changed
                var binding = new Binding("VerticalOffset") { Source = scrollViewer };
                var offsetChangeListener = DependencyProperty.RegisterAttached(
                    "ListenerOffset",
                    typeof(object),
                    typeof(UserControl),
                    new PropertyMetadata(OnScrollChanged));
                scrollViewer.SetBinding(offsetChangeListener, binding);
        }
