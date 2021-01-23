    private void initScrollViewerMonitor(object sender, EventArgs e)
        {   
               //get the ScrollViewer from the ListBox
               scrollViewer = lstEventHistory.GetScrollHost();
                //attach to custom binding to check if ScrollViewer verticalOffset property has changed
                var binding = new Binding("VerticalOffset") { Source = scrollViewer };
                var offsetChangeListener = DependencyProperty.RegisterAttached(
                    "ListenerOffset",
                    typeof(object),
                    typeof(UserControl),
                    new PropertyMetadata(OnScrollChanged));
                scrollViewer.SetBinding(offsetChangeListener, binding);
        }
