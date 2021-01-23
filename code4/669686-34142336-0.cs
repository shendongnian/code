    public class Line {
		public Point p1, p2;
		public Line(Point p1, Point p2) {
			this.p1 = p1;
			this.p2 = p2;
		}
		public Point[] getPoints(int quantity) {
			var points = new Point[quantity];
			int ydiff = p2.Y - p1.Y, xdiff = p2.X - p1.X;
			double slope = (double)(p2.Y - p1.Y) / (p2.X - p1.X);
			double x, y;
			--quantity;
			for (double i = 0; i < quantity; i++) {
				y = slope == 0 ? 0 : ydiff * (i / quantity);
				x = slope == 0 ? xdiff * (i / quantity) : y / slope;
				points[(int)i] = new Point((int)Math.Round(x) + p1.X, (int)Math.Round(y) + p1.Y);
			}
			points[quantity] = p2;
			return points;
		}
	}
