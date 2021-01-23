    private async void ItemListView_SelectionChanged(object sender,
                                                     SelectionChangedEventArgs e)
    {
        MyList.IsEnabled = false;
        var result = await LoadMyPage();
    
        Result.Text = result;
    
        MyList.IsEnabled = true;
    }
