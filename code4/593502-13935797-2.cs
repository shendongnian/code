    	private async void button_Click(object sender, RoutedEventArgs e)
	{
			// Put here your logic to prevent user interaction during the operation's execution.
			// Ex: this.mainPanel.IsEnabled = false;
			// Or: this.modalPanel.Visibility = Visible;
			// etc
			try
			{
			
				// The await keyword will segment your method execution and post the continuation in the UI thread
				// The Task.Factory.StartNew will run the time consuming method in the ThreadPool, whether it takes the long or the short path
				bool result = await The Task.Factory.StartNew(()=>this.UnloadData());
				// Do whatever with the result
			}
			finally
			{
				// Reenable the user interaction
				// Ex: this.mainPanel.IsEnabled = true;
			}
	}
    
