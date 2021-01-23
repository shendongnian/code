    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        var listItem = App.SelectedPhone;
        progressBar1.IsEnabled = true;
        progressBar1.IsIndeterminate = true;
        //Query database
        try
        {
            items = await phoneTable
                    .Where(phone => phone.Model == listItem.Model)
                    .ToCollectionAsync();
         }
         catch (MobileServiceInvalidOperationException)
         {
             MessageBox.Show("Error", "Error", MessageBoxButton.OK);
         }
         MainListBox.ItemsSource = items;
         //End progressBar
         progressBar1.IsEnabled = false;
         progressBar1.Visibility = System.Windows.Visibility.Collapsed;
         progressBar1.IsIndeterminate = false;
    }
