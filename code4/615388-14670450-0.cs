	private void OnRecordButton_Checked(object sender, RoutedEventArgs e)
	{
		if (recordButton.IsChecked.GetValueOrDefault())
		{
			// Do your own logic to execute command. with-or-without command parameter.
			viewModel.ToggleRecordCommand.Execute(null);
		}
	}
