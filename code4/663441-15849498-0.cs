	private void Form2_Paint(object sender, PaintEventArgs e)
	{
		if (IsDrowing)
		{
			g = e.Graphics;
			gp = new GraphicsPath();
			gp.AddEllipse(r);
			gp.Widen(new Pen(Color.Red, 10));
			Pen pen = new Pen(Color.Red, 1);
			pen.DashStyle = DashStyle.Dash;
			g.DrawPath(pen, gp);
		}
	}
