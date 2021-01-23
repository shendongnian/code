    private async void btnAsync01_Click(object sender, RoutedEventArgs e)
    {
        UpdateTxtLog("click button: " + System.DateTime.Now);
        await method01Async();
        UpdateTxtLog("after ethod01Async: " + System.DateTime.Now);
    }
	private async Task method01Async()
	{
		return await TaskEx.Run(() =>
		{
			UpdateTxtLog("Enter method01Async: " + System.DateTime.Now);
			Thread.Sleep(10000);
			UpdateTxtLog("exit method01Async: " + System.DateTime.Now);
		});
	}
