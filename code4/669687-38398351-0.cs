    public List<Point> GetPoints(Point p1, Point p2)
    {
    	List<Point> points = new List<Point>();
		// no slope (vertical line)
		if (p1.X == p2.X)
		{
			for (double y = p1.Y; y <= p2.Y; y++)
			{
				Point p = new Point(p1.X, y);
				points.Add(p);
			}
		}
		else
		{
			// swap p1 and p2 if p2.X < p1.X
			if (p2.X < p1.X)
			{
				Point temp = p1;
				p1 = p2;
				p2 = temp;
			}
			double deltaX = p2.X - p1.X;
			double deltaY = p2.Y - p1.Y;
			double error = -1.0f;
			double deltaErr = Math.Abs(deltaY / deltaX);
			double y = p1.Y;
			for (double x = p1.X; x <= p2.X; x++)
			{
				Point p = new Point(x, y);
				points.Add(p);
				Debug.WriteLine("Added Point: " + p.X.ToString() + "," + p.Y.ToString());
				error += deltaErr;
				Debug.WriteLine("Error is now: " + error.ToString());
				while (error >= 0.0f)
				{
					Debug.WriteLine("	Moving Y to " + y.ToString());
					y++;
					points.Add(new Point(x, y));
					error -= 1.0f;
				}
			}
			if (points.Last() != p2)
			{
				int index = points.IndexOf(p2);
				points.RemoveRange(index + 1, points.Count - index - 1);
			}
		}
		return points;
	}
