    private void MyCheckBoxLoaded(object sender, System.Windows.RoutedEventArgs e)
    {
        var cb = (CheckBox)sender;
        cb.SetBinding(Control.ForegroundProperty, new System.Windows.Data.Binding("DisabledColor.Bindablecolor") { Source = this });
    }
