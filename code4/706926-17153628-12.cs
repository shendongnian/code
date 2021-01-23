    public string From { get; set; }
    public string To { get; set; }
	private IList<Connection> connections = new List<Connection>();
	private void Button_Click_2(object sender, RoutedEventArgs e)
	{
		MyBox box1 = boxes.Single(b => b.Header == From);
		MyBox box2 = boxes.Single(b => b.Header == To);
		Connection conn = new Connection { Box1 = box1, Box2 = box2, Line = new Line { StrokeThickness = 1, Stroke = Brushes.Black } };
		connections.Add(conn);
		RefreshLinesPositions();
		panel.Children.Add(conn.Line);
	}
