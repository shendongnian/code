        private void Pushpin_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
		{
			Pushpin p = sender as Pushpin;
			if (p != null && p.Tag != null)
			{
				PushpinModel model = p.Tag as PushpinModel;
				if (model != null) ShowPushpinContent(model);
			}
		}
		private void ShowPushpinContent(PushpinModel model)
		{
			PushpinPopup.IsOpen = false;
			PushpinPopup.DataContext = model;
			PushpinPopup.IsOpen = true;
			MapLayer.SetPosition(PushpinPopup, model.Location);
			currentmodel = model;
		}
