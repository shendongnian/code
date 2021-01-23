    private void txtEdit_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(!IsSelectedItemText)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text.Contains("[") || tb.Text.Contains("]"))
            {
                MessageBox.Show("Cannot enter '[' or ']' characters!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                tb.Text = "";
            }
        }
        IsSelectedItemText = false;
    }
