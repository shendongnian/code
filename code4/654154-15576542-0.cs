    private void comboBox8_LostFocus(object sender, RoutedEventArgs e)
    {
        ...
            else if (8int <= 7int && 8int >= 100)
            {
                if((sender as ComboBox).IsDropDownOpen == false)
                    MessageBox.Show("Error description", "Error!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            ...
    }
