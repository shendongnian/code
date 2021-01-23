    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        //Recent is the ListBox in the view that is populated from the ObservableCollection
        //Recent.ItemsSource = PictureRepository.Instance.Pictures.OrderBy(x => x.DateTaken);
        Recent.ItemsSource = App.PictureList.Pictures;
    }
