    private void txtEdit_TextChanged(object sender, TextChangedEventArgs e)
    {
    string a = (sender as TextBox).Text.substing(0,1).subsctring;
    a = a.Remove(0, 1);
                a = a.Remove(a.Length - 1, 1);
                if (a.Contains('[') || a.Contains(']') )
                {
                    MessageBox.Show("Cannot enter '[' or ']' characters!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                (sender as TextBox).Text = "[" + a.Replace("[", "").Replace("]", "") + "]";
        
    }
