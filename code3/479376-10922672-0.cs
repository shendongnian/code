    ... Title="MainWindow" x:Name="theWindow" SizeToContent="WidthAndHeight">
    private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
    {
        theWindow.SizeToContent = SizeToContent.Manual;
        var messages = new ObservableCollection<string>
            {
                "This is a long string to demonstrate that the list" + 
                " box content is determining window width"
            };
        for (int i = 0; i < 16; i++)
        {
            messages.Add("Test" + i);
        }
        for (int i = 0; i < 4; i++)
        {
            messages.Add("this text should be visible by vertical scrollbars only");
        }
        ListBox1.ItemsSource = messages;
    }
