    public async Task<bool> UnloadData(){
		if(...){
			// The await keyword will segment your method execution and post the continuation in the UI thread
			// The Task.Factory.StartNew will run the time consuming method in the ThreadPool
			await Task.Factory.StartNew(()=>LaunchMyTimeConsumingMethodWithBackgroundWorker());
			// The return statement is the continuation and will run in the UI thread after the consuming method is executed
			return true;
		}
		// If it came down this path, the execution is synchronous and is completely run in the UI thread		
		return false;
	}
    private async void button_Click(object sender, RoutedEventArgs e)
    {
			// Put here your logic to prevent user interaction during the operation's execution.
			// Ex: this.mainPanel.IsEnabled = false;
			// Or: this.modalPanel.Visibility = Visible;
			// etc
			
			try
			{
				bool result = await this.UnloadData();
				// Do whatever with the result
			}
			finally
			{
				// Reenable the user interaction
				// Ex: this.mainPanel.IsEnabled = true;
			}
	}
