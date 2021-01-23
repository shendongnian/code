    private ListView _listViewInstance;
    private void CountryListButton_OnClick(object sender, RoutedEventArgs e)
    {
        CountryListPopupGrid.Width = Window.Current.Bounds.Width;
        CountryListPopupGrid.Height = Window.Current.Bounds.Height;
        _listViewInstance = (ListView)ListViewTemplate.LoadContent();
        CountryListPopupGrid.Children.Add(_listViewInstance);
        CountryListPopup.IsOpen = true;
    }
    private void CountryOKButton_OnClick(object sender, RoutedEventArgs e)
    {
        MainPageViewModel vm = this.DataContext as MainPageViewModel;
        foreach (string filteredCountry in vm.FilteredCountries)
        {
            Debug.WriteLine(filteredCountry);
        }
        CountryListPopup.IsOpen = false;
        CountryListPopupGrid.Children.Remove(_listViewInstance);
        _listViewInstance = null;
    }
