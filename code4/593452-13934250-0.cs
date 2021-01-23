	protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			// the "MyViewModel.OpenSaveDialogRequest" can be any string.. it just needs to synch up with what was sent from the viewmodel below
			Messenger.Default.Register<CustomObjectWithParams>(this, "MyViewModel.OpenSaveDialogRequest", objParams => ShowSaveDialog(objParams));
			base.OnNavigatedTo(e);
		}
		
		private void ShowSaveDialog(CustomObjectWithParams obj) {
			// do your  open save here in the UI thread
		}
		// be smart, make sure you unregister this listener when you navigate away!
		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			Messenger.Default.Unregister<CustomObjectWithParams>(this);
			base.OnNavigatedFrom(e);
		}
