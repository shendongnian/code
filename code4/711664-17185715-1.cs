	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		_isDesignMode = Windows.Forms.Utilities.IsDesignMode(this);
	}
