    //the method
    public async Task WaitForDriveAsync(string path, string waitingToastText)
    {
    	int width = 300;
    	int height = 125;
    	TextBlock toastTextBlock = new TextBlock() { Text = waitingToastText, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, FontSize = 23, Width = (width - 15), TextWrapping = TextWrapping.WrapWithOverflow };
    	Grid notification = new Grid();
    	notification.Width = width;
    	notification.Height = height;
    	notification.Background = Brushes.Red;
    	notification.Margin = new System.Windows.Thickness(0, 27, 0.4, 0);
    	notification.VerticalAlignment = VerticalAlignment.Top;
    	notification.HorizontalAlignment = HorizontalAlignment.Right;
    	notification.Children.Add(toastTextBlock);
    
    	grdMain.Children.Add(notification);
    
    	while (!Directory.Exists(path))
    	{
    		await Task.Delay(1000);
    	}
    
    	grdMain.Children.Remove(notification);
    }
    
    //to call it
    private async void btnBackupNow_Click(object sender, RoutedEventArgs e)
    {
    	await WaitForDriveAsync(@"B:\", "Please connect your drive.");
    }
