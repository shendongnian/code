	private static void OnHasBeenReadChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if ((bool)e.NewValue)
		{
			VisualStateManager.GoToState(d as Control, "Read", true);
		}
		else
		{
			VisualStateManager.GoToState(d as Control, "Unread", true);
		}
	}
