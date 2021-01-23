	public async void ShowDialogAsyncSample()
	{
		var msg = new Message();
		if (await msg.ShowDialogAsync())
		{
			// Now you can use DialogResultAsync as you need.
			System.Diagnostics.Debug.Write(msg.DialogResultAsync);
		}
	}
