    TextBox txtEdit = new TextBox();
    txtEdit.Text = "[Test]";
    txtEdit.TextChanged += txtEdit_TextChanged;
    private void txtEdit_TextChanged(object sender, TextChangedEventArgs e)
    {
        if ((sender as TextBox).Text.Contains("[") || (sender as TextBox).Text.Contains("]"))
        {
            MessageBox.Show("Cannot enter '[' or ']' characters!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            (sender as TextBox).Text = "";
        }
    }
