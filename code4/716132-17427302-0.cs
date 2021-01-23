    private void MainListBox_SelectionChanged(object sender,  SelectionChangedEventArgs e)
    {
        App.SelectedPhone = MainListBox.SelectedItem;
        NavigationService.Navigate(new Uri("/ViewModels/Phones/PhoneItemView.xaml, UriKind.Relative));
    }
