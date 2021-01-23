    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        MenuItem menuItem = (MenuItem)sender;
        MessageBox.Show("You chose to  " + menuItem.Header.ToString(),"Result",MessageBoxButton.OK);
    }
