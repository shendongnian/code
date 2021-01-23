    **private void TimePicker_LostFocus(object sender, System.Windows.RoutedEventArgs e)
    {
        if (e.OriginalSource.GetType().Name != e.Source.GetType().Name)
        { 
            Validate();
        }
    }**
