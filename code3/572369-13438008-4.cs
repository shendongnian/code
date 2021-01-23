    private void panFill_MouseMove(object sender, MouseEventArgs e)
    {
        if (inDrag) {
            using (Graphics g = panFill.CreateGraphics) {
                g.SmoothingMode = Drawing2D.SmoothingMode.None;
                //we store new pos. here as it's used to calculate
                //delta for what we need to redraw
                regNew = e.Location;
                ClearRegion(g);
                regOld = regNew;
                DrawRegion(g);
                }
            }
	}
