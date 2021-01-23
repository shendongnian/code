 	protected override void OnCreateControl()
	{
		base.OnCreateControl();
		var myToolTip = new System.Windows.Forms.ToolTip
		{
			AutomaticDelay = 5000,
			AutoPopDelay = 50000,
			InitialDelay = 100,
			ReshowDelay = 500
		};
		myToolTip.SetToolTip(this, this.Text);
	}
