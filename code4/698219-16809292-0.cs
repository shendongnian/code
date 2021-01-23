    namesView = CollectionViewSource.GetDefaultView(names);
    namesView.Filter = item =>
    {
        if (myTextBox.Text.Length > 0)
        {
            return ((string)item).StartsWith(myTextBox.Text);
        }
        return true;
    };
    
    private void myTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        namesView.Refresh();
    }
