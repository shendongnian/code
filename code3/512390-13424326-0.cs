    private Point GetExtremity(Point center, double radius, double orientation)
            {
                return new Point(
                    center.X + Math.Cos(orientation) * radius,
                    center.Y + Math.Sin(orientation) * radius
                    );
            }
    
            public void DrawUniformShape(DrawingContext context, Brush brush, Pen pen, Point center, double radius, int sides, double orientationRadians)
            {
                context.DrawGeometry(
                    brush,
                    pen,
                    new PathGeometry(
                        Enumerable.Repeat(
                            new PathFigure(
                                GetExtremity(center, radius, orientationRadians),
                                from vertex in Enumerable.Range(1, sides - 1)
                                let angle = orientationRadians + vertex * 2 * Math.PI / sides
                                select new LineSegment(GetExtremity(center, radius, angle), true),
                                true
                                ),
                            1
                            )
                        )
                    );
            }
    
            public void DrawBarnColouredHexagon(DrawingContext context, Point center, double radius, double orientation)
            {
                DrawUniformShape(
                    context,
                    Brushes.Red,
                    new Pen(Brushes.White, 2),
                    center,
                    radius,
                    6,
                    0
                    );
            }
