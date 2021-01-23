    private void cmbCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = sender as ComboBox;
        if (null != comboBox)
        {
            var item = comboBox.SelectedItem as ComboBoxItem;
            if (null != item)
            {
                Console.WriteLine(item.Uid);
            }
        }
    }
