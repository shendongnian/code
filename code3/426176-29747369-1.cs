    	private void button1_Click(object sender, RoutedEventArgs e)
		{
			Task.Run(() =>
			{
				Dispatcher.Invoke(new Action(() =>
				{
					label1.Content = "Waiting";
				}), null);
				Thread.Sleep(2000);
				Dispatcher.Invoke(new Action(() =>
				{
					label1.Content = "Done";
				}), null);
			});
		}
