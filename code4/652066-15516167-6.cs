        NewsItem selectedItem = (sender as ListBox).SelectedItem;
        if (selectedItem != null)
        {
            (Application.Current as App).selectedNewsItem = selectedItem;
            // Navigate to your new page
            NavigationService.Navigate(new Uri("/YourNewPage.xaml", UriKind.Relative));
        }
