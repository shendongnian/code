    // Subscribe on ComboBoxItem-s events.
    comboBox.Items.Cast<ComboBoxItem>().ToList().ForEach(i => i.PreviewMouseDown += ComboBoxItem_PreviewMouseDown);
    private void ComboBoxItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
         // your handler logic...         
    }
