    private void CheckBoxLoaded(object sender, RoutedEventArgs e)
    {
            var prop = e.GetType().GetProperty("IsChecked", 
                       BindingFlags.Instance | BindingFlags.Public);
            // read the current value
            var current = (bool)prop.GetValue(sender, null);
            //and toggle it
            prop.SetValue(sender, !current, null);
    } 
