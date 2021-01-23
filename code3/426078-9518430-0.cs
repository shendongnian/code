    private void cmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        cp1.Content = null;
        cp1.DataContext = null;
        cp1.Content = cmbBox.SelectedItem;
    }
