    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var scrollViewer = userControl.Content as ScrollViewer;
        if (scrollViewer != null)
        {
            var content = scrollViewer.Content;
            scrollViewer.Content = null;
            userControl.Content = content;
        }
        else
        {
            var content = userControl.Content;
            userControl.Content = null;
            userControl.Content = new ScrollViewer { Content = content };
        }
    }
