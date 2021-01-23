	private void comboBox_DropDownClosed(object sender, EventArgs e)
	{
		Point m = Mouse.GetPosition(this);
		VisualTreeHelper.HitTest(this, new HitTestFilterCallback(FilterCallback),
			new HitTestResultCallback(ResultCallback), new PointHitTestParameters(m));
	}
	private HitTestFilterBehavior FilterCallback(DependencyObject o)
	{
		var c = o as Control;
		if ((c != null) && !(o is MainWindow))
		{
			if (c.Focusable)
			{
				c.Focus();
				return HitTestFilterBehavior.Stop;
			}
		}
		return HitTestFilterBehavior.Continue;
	}
	private HitTestResultBehavior ResultCallback(HitTestResult r)
	{
		return HitTestResultBehavior.Continue;
	}
