    private void ComboBox_Loaded(object sender, RoutedEventArgs e)
    {
        ((ComboBox)sender).DropDownClosed -= ComboBox_OnDropDownClosed;
        ((ComboBox)sender).DropDownClosed += new System.EventHandler(ComboBox_OnDropDownClosed);
    }
