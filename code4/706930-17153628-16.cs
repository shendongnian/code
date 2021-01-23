	private void Button_Click_2(object sender, RoutedEventArgs e)
	{
		MyBox box1 = boxes.Single(b => b.Header == From);
		MyBox box2 = boxes.Single(b => b.Header == To);
		Connection conn = new Connection
		{
			Box1 = box1,
			Box2 = box2,
			Line = new Line { StrokeThickness = 1, Stroke = Brushes.Black },
			Node1 = new Node { Text = new TextBox() },
			Node2 = new Node { Text = new TextBox() }
		};
		connections.Add(conn);
		panel.Children.Add(conn.Line);
		panel.Children.Add(conn.Node1.Text);
		panel.Children.Add(conn.Node2.Text);
		RefreshLinesPositions();
	}
