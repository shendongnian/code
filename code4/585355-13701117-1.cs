	public void QuitApplication(FormClosingEventArgs closeArgs, bool forceQuit)
	{
		if (forceQuit)
		{
			return;
		}
		
		if (Properties.App.Default.AskToExit)
		{
			if (YesNoMessageBox("Really Quit?", "Are you sure you want to quit?") != DialogResult.Yes)
			{
				// Cancel exit
				closeArgs.Cancel = true;
				return;
			}
		}
		
		if (Properties.App.Default.AskToSave)
		{
			if (YesNoMessageBox("Save Before Quit?", "Would you like to save your settings before you Quit?") == DialogResult.Yes)
			{
				// Save
			}
		}
	}
