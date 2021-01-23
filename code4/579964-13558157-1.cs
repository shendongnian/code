    private void comboboxA_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        for (int i = 0; i <= comboboxB.Items.Count -1; i++)
        {
            if (((ComboBoxItem)(comboboxB.Items[i])).Content.ToString() == ((ComboBoxItem)comboboxA.SelectedItem).Content.ToString())
            {
                ((ComboBoxItem)(comboboxB.Items[i])).Visibility = System.Windows.Visibility.Collapsed;
            }
            else
                ((ComboBoxItem)(comboboxB.Items[i])).Visibility = System.Windows.Visibility.Visible;
        }
    }
