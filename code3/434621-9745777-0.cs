	using(var gp = new System.Drawing.Drawing2D.GraphicsPath())
	{
		// Here goes series of AddLine() calls.
		// You must 
		// gp.AddLine(0, 0, leftPanel.Width, 0);
		// ...
		gp.CloseFigure();
		return new Region(gp);
	}
