	private void SetGrandParentViewGestureEnabled(bool enabled)
	{
		foreach(UIGestureRecognizer g in this.View.Superview.Superview.GestureRecognizers)
		{
			g.Enabled = enabled;
		}
	}
	void HandleButtonSubmitTouchDown (object sender, EventArgs e)
	{
		SetGrandParentViewGestureEnabled(false);
	}
	void HandleButtonSubmitTouchUpInside (object sender, EventArgs e)
	{
		// => Do treatments here!
		
		SetGrandParentViewGestureEnabled(true);
	}
