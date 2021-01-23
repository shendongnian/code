		protected override void OnKeyDown(KeyEventArgs e)
		{
			if(e.SystemKey == Key.LeftAlt)
			{
				myMenu.Visibility = Visibility.Visible;
				// e.Handled = true; You need to evaluate if you really want to mark this key as handled!
			}
			base.OnKeyDown(e);
		}
