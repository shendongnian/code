	private void Button_Paint(object sender, PaintEventArgs e)
	{
		Graphics g = e.Graphics;
		if (MyFormIsValid()) {
			g.DrawString("This is a diagonal line drawn on the control",
				new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(30, 30));
			g.DrawLine(System.Drawing.Pens.Red, btn.Left, btn.Top,
				btn.Right, btn.Bottom);
		}
		else {
			g.FillRectangle(
				new LinearGradientBrush(PointF.Empty, new PointF(0, btn.Height), Color.White, Color.Red),
				new RectangleF(PointF.Empty, btn.Size));
		}
	}
