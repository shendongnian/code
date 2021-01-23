    	protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			// Reference to Local Application Settings.
			Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
			// Reading settings back.
			object mySavedOption1;
			localSettings.Values.TryGetValue("myOption1Key", out mySavedOption1);
			if (mySavedOption1 != null)
				myOption1.IsChecked = (bool)mySavedOption1;
		}
		private void myOption1_Checked_1(object sender, RoutedEventArgs e)
		{
			// Reference to Local Application Settings.
			Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
			// Persisting simple Application Settings.
			localSettings.Values["myOption1Key"] = myOption1.IsChecked;
			
		}
