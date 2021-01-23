	protected override void OnNavigatedTo(NavigationEventArgs e)
	{
		base.OnNavigatedTo(e);
		//remember don't show MessageBoxes in OnNavigatedTo..
        // better to move stuff over to Loaded as much as you can anyway
		this.Loaded += RunOnPageLoaded; //you could hook up to this event via the Designer too
	}
	void RunOnPageLoaded(object sender, RoutedEventArgs e)
	{
		bool doLoad = true;
		FrameworkDispatcher.Update();
		if (!MediaPlayer.GameHasControl)
		{
			doLoad = PromptUserAboutBackgroundMusic();
			if (doLoad) MediaPlayer.Pause();
		}
		if (doLoad)
		{
			LoadMediaFiles();
		}
	}
	private bool PromptUserAboutBackgroundMusic()
	{
		var result = MessageBox.Show("Do you want to stop your background music to play this recording?",
									 "Stop music?", MessageBoxButton.OKCancel);
		if (result == MessageBoxResult.OK) return true;
		return false;
	}
	private void LoadMediaFiles()
	{
		//load your media files into your mediaelements here
		//mediaElement.AutoPlay = true;
		//mediaElement.Source = ...
	}
