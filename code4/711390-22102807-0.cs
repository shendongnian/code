    			CoreApplicationView v = Windows.ApplicationModel.Core.CoreApplication.MainView;
			var bounds = v.CoreWindow.Bounds;
			double w = bounds.Width;
			double h = bounds.Height;
			switch (DisplayProperties.ResolutionScale)
			{
				case ResolutionScale.Scale140Percent:
					w = Math.Round(w * 1.4);
					h = Math.Round(h * 1.4);
					break;
				case ResolutionScale.Scale180Percent:
					w = Math.Round(w * 1.8);
					h = Math.Round(h * 1.8);
					break;
			}
			ScreenSize resolution = new ScreenSize(w, h);
			if (ApplicationView.Value == ApplicationViewState.FullScreenLandscape)
				resolution = new ScreenSize(w, h);
			else if (ApplicationView.Value == ApplicationViewState.FullScreenPortrait)
			{
				resolution = new ScreenSize(h, w);
			}
			else if (ApplicationView.Value == ApplicationViewState.Filled)
			{
				resolution = new ScreenSize(w + 320.0 + 22.0, h); //snapped mode grip
			}
