	protected override void OnKeyDown(KeyEventArgs e)
	{
		base.OnKeyDown(e);
		if (e.KeyCode == Keys.Enter)
		{
			e.Handled = true;
            //  Move focus to next control in parent container
			Parent.SelectNextControl(this, true, true, false, false);
		}
	}
