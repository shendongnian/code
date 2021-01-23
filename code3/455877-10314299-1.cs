    private void StockItemOverview_Loaded(object sender, RoutedEventArgs e)
        {
            this.listBox.ItemsSource = App.ViewModel.StockItemList;
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }
