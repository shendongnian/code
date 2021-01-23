    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        var gvData = new ObservableCollection<MyData>();
        for (int i = 0; i < 8; i++)
        {
            gvData.Add(new MyData
            {
                ID = i,
                Image = new BitmapImage(new Uri("ms-appx:///Assets/Logo.png")), //You can add any image
                Title = "Title " + i,
                Subtitle = "Subtitle " + i
            });
        }
        itemGridView.ItemsSource = gvData;
    }
    
    private void MainPage_Click(object sender, ItemClickEventArgs e)
    {
        MyData output = e.ClickedItem as MyData;
        int ClickValue = output.ID;
        if (ClickValue == 0)
        {
            this.Frame.Navigate(typeof(ItemsPageRSS));
            //TODO : Do whatever you want
        }
    
        //.....
        //TODO : Do operations for other items as well.
    }
