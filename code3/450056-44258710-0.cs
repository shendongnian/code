    //check that the button is untoggled
    if (this.MyToggleButton.IsChecked == false)
    {
        //set button toggled
        this.MyToggleButton.IsChecked = true;
        //then raise a click evt
        this.MyToggleButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
    }
