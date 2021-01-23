	private void ellipse1_MouseDown(object sender, MouseButtonEventArgs e)
	{
		Mouse.Capture(ellipse1);
		_oldPoint = e.GetPosition(grid1);
		ellipse1.MouseMove += new MouseEventHandler(ellipse1_MouseMove);
	}
	private void ellipse1_MouseUp(object sender, MouseButtonEventArgs e)
	{
		Mouse.Capture(null);
		ellipse1.MouseMove -= new MouseEventHandler(ellipse1_MouseMove);
	}
