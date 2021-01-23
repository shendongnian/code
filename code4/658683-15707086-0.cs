	PointCollection points = new PointCollection();
	zigzag = new Polyline();
	zigzag.Stroke = Brushes.Black;
	for (int i = 1; i < 60 - 3; i = i + 3)
	{
		points.Add(
			new Point(
				10.5f + i,
				10.5f + (i % 2 == 0 ? 2 : 5)
			 ));
	}
	this.zigzag.Points = points;
	RenderOptions.SetEdgeMode(Panel1, EdgeMode.Aliased);
	Panel1.Children.Add(zigzag);
