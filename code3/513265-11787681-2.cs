    private void EventSetter_OnHandler(object sender, RoutedEventArgs e)
    {
        TextBox txt = sender as TextBox;
        if( !txt.IsMouseOver || Mouse.LeftButton != MouseButtonState.Pressed)
            if (txt != null) txt.SelectAll();
    }
