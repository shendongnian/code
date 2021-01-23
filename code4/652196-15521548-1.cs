    private void txtEdit_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox tb = sender as TextBox;
        if(!IsSelectedItemText)
        {            
            if (tb.Text.Contains("[") || tb.Text.Contains("]"))
            {
                MessageBox.Show("Cannot enter '[' or ']' characters!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                tb.Text = "";
            }
        }
        else
        {
            //Set text from selected item
        }
        
        IsSelectedItemText = false;
    }
