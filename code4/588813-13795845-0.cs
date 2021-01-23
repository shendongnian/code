    public delegate void TappedEventHandler(object sender, TappedRoutedEventArgs e)
    {
        var item = (int)((CheckBox)sender).Tag;
        // do something with the value
    }
