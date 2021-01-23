    DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        dataTransferManager.DataRequested += ShareTextHandler;
    }
    
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        dataTransferManager.DataRequested -= ShareTextHandler;
    }
    
    private void ShareTextHandler(DataTransferManager sender, DataRequestedEventArgs e)
    {
        DataRequest request = e.Request;
        request.Data.Properties.Title = "Share Text Example"; // You must have to set title.
        request.Data.Properties.Description = "A demonstration that shows how to share text.";
        request.Data.SetText(ShareText.Text);
    }
    private void Share_Click_1(object sender, RoutedEventArgs e)
    {
        DataTransferManager.ShowShareUI();
    }
