	private void RefreshLinesPositions()
	{
		foreach (Connection conn in connections)
		{
			Point p1 = conn.Box1.TranslatePoint(new Point(0, 0), panel);
			Point p2 = conn.Box2.TranslatePoint(new Point(0, 0), panel);
			double t1 = p1.Y;
			double b1 = p1.Y + conn.Box1.ActualHeight;
			double l1 = p1.X;
			double r1 = p1.X + conn.Box1.ActualWidth;
			double t2 = p2.Y;
			double b2 = p2.Y + conn.Box2.ActualHeight;
			double l2 = p2.X;
			double r2 = p2.X + conn.Box2.ActualWidth;
			if (r1 < l2)
			{
				conn.Line.X1 = r1;
				conn.Line.Y1 = t1 + (b1 - t1) / 2;
				conn.Line.X2 = l2;
				conn.Line.Y2 = t2 + (b2 - t2) / 2;
				conn.Line.Visibility = Visibility.Visible;
				conn.Node1.Text.RenderTransform = new TranslateTransform(r1, t1 + (b1 - t1) / 2);
				conn.Node2.Text.RenderTransform = new TranslateTransform(l2 - conn.Node2.Text.ActualWidth, t2 + (b2 - t2) / 2);
			}
			else if (r2 < l1)
			{
				conn.Line.X1 = l1;
				conn.Line.Y1 = t1 + (b1 - t1) / 2;
				conn.Line.X2 = r2;
				conn.Line.Y2 = t2 + (b2 - t2) / 2;
				conn.Line.Visibility = Visibility.Visible;
				conn.Node1.Text.RenderTransform = new TranslateTransform(l1 - conn.Node1.Text.ActualWidth, t1 + (b1 - t1) / 2);
				conn.Node2.Text.RenderTransform = new TranslateTransform(r2, t2 + (b2 - t2) / 2);
			}
			else if (b1 < t2)
			{
				conn.Line.X1 = l1 + (r1 - l1) / 2;
				conn.Line.Y1 = b1;
				conn.Line.X2 = l2 + (r2 - l2) / 2;
				conn.Line.Y2 = t2;
				conn.Line.Visibility = Visibility.Visible;
				conn.Node1.Text.RenderTransform = new TranslateTransform(l1 + (r1 - l1) / 2, b1);
				conn.Node2.Text.RenderTransform = new TranslateTransform(l2 + (r2 - l2) / 2, t2 - conn.Node2.Text.ActualHeight);
			}
			else if (b2 < t1)
			{
				conn.Line.X1 = l1 + (r1 - l1) / 2;
				conn.Line.Y1 = t1;
				conn.Line.X2 = l2 + (r2 - l2) / 2;
				conn.Line.Y2 = b2;
				conn.Line.Visibility = Visibility.Visible;
				conn.Node1.Text.RenderTransform = new TranslateTransform(l1 + (r1 - l1) / 2, t1 - conn.Node1.Text.ActualHeight);
				conn.Node2.Text.RenderTransform = new TranslateTransform(l2 + (r2 - l2) / 2, b2);
			}
			else
			{
				conn.Line.Visibility = System.Windows.Visibility.Collapsed;
			}
		}
	}
