    private void EventSetter_OnHandler(object sender, RoutedEventArgs e)
    {
        TextBox txt = sender as TextBox;
        Point position = Mouse.GetPosition(txt);
        // if Mouse position is not in the TextBox Client Rectangle
        // and Mouse Button not Pressed.
        if((!(new Rect(0,0,txt.Width,txt.Height)).Contains(position)) || ( Mouse.LeftButton != MouseButtonState.Pressed))
            if (txt != null) txt.SelectAll();
    }
