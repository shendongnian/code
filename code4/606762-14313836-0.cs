    private void MainPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxGroupName.Text))
        {
            textBoxGroupName.Focus(FocusState.Programmatic);
        }
    }
