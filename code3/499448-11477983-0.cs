	Path path = c.GetTemplateChild("PART_Path") as Path;
	if (path != null)
	{
		Point p = new Point(
			Math.Cos((this.StartAngle + this.Angle) * (Math.PI / 180)) * this.Radius,
			Math.Sin((this.StartAngle - this.Angle) * (Math.PI / 180)) * this.Radius);
		Point q = new Point(
			Math.Cos((this.StartAngle) * (Math.PI / 180)) * this.Radius,
			Math.Sin((this.StartAngle) * (Math.PI / 180)) * this.Radius);
		path.Data = new PathGeometry()
		{
			Figures = new PathFigureCollection()
			{
				new PathFigure()
				{
					StartPoint = new Point(0, 0),
					Segments = new PathSegmentCollection()
					{
						new LineSegment() { Point = p }
					}
				},
				new PathFigure()
				{
					StartPoint = new Point(0, 0),
					Segments = new PathSegmentCollection()
					{
						new LineSegment() { Point = q }
					}
				},
				new PathFigure()
				{
					StartPoint = new Point(p.X/3, p.Y/3),
					Segments = new PathSegmentCollection()
					{
						new ArcSegment()
						{
							IsLargeArc = (Math.Abs(this.Angle) % 360) > 180,
							RotationAngle = Math.Abs(this.Angle) * (Math.PI / 180),
							SweepDirection = this.Angle < 0 ? SweepDirection.Counterclockwise : SweepDirection.Clockwise,
							Point = new Point(q.X/ 3, q.Y/ 3),
							Size = new Size(this.Radius / 3, this.Radius/3)
						}
					}
				},
			}
		};
	}
