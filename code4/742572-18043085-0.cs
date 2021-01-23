    int k = 20;
	
	for (int i = 0; i < 4; i++)
	{
		Button btn = new Button();
		btn.Content = i.ToString();
		btn.Height = 20;
		btn.Width = 20;
		Canvas.SetTop(btn, k); // 20
		Canvas.SetLeft(btn, 20); // 10 
		Canvas1.Children.Add(btn);
		btn.PreviewMouseDown += (source, e) =>
		{
			if (LastClicked != null)
			{
				// Get button locations.
				Point LastClickedLocation = LastClicked.TransformToAncestor(Canvas1).Transform(new Point(0, 0));
				Point ThisClickedLocation = ((Button)source).TransformToAncestor(Canvas1).Transform(new Point(0, 0));
				// Stop same side lines.
				if (LastClickedLocation.X != ThisClickedLocation.X)
				{
					Line line = new Line();
					line.X1 = LastClickedLocation.X;
					line.Y1 = LastClickedLocation.Y + btn.Height / 2; // Button Middle.
					line.X2 = ThisClickedLocation.X + btn.Width; // Adjust Left side.
					line.Y2 = ThisClickedLocation.Y + btn.Height / 2; // Button Middle.
					line.Stroke = Brushes.Red;
					line.StrokeThickness = 4;
					Canvas1.Children.Add(line);
				}
			}
			LastClicked = (Button)source;
		};
		k += 20;
	}
	k = 20; // Reset k, this is why your buttons weren't aligned.
	for (int i = 0; i < 4; i++)
	{
		Button btn2 = new Button();
		btn2.Content = i.ToString();
		btn2.Height = 20;
		btn2.Width = 20;
		Canvas.SetTop(btn2, k); // 20
		Canvas.SetRight(btn2, 20); // 10
		Canvas1.Children.Add(btn2);
		btn2.PreviewMouseDown += (source, e) =>
		{
			if (LastClicked != null)
			{
				// Get button locations.
				Point LastClickedLocation = LastClicked.TransformToAncestor(Canvas1).Transform(new Point(0, 0));
				Point ThisClickedLocation = ((Button)source).TransformToAncestor(Canvas1).Transform(new Point(0, 0));
				// Stop same side lines.
				if (LastClickedLocation.X != ThisClickedLocation.X)
				{
					Line line = new Line();
					line.X1 = LastClickedLocation.X + btn2.Width; // Adjust Left side.
					line.Y1 = LastClickedLocation.Y + btn2.Height / 2; // Button Middle.
					line.X2 = ThisClickedLocation.X;
					line.Y2 = ThisClickedLocation.Y + btn2.Height / 2; // Button Middle.
					line.Stroke = Brushes.Red;
					line.StrokeThickness = 4;
					Canvas1.Children.Add(line);
				}
			}
			LastClicked = (Button)source;
		};
		k += 20;
	}
