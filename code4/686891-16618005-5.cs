	public class ExampleContent : Control
	{
		public ExampleContent()
		{
			this.DoubleBuffered = true;
		}
		static Random random = new Random();
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			var graphics = e.Graphics;
			// random color to make the clip rectangle visible in an unobtrusive way
			var color = Color.FromArgb(random.Next(160, 180), random.Next(160, 180), random.Next(160, 180));
			graphics.Clear(color);
			Debug.WriteLine(this.AutoScrollOffset.X.ToString() + ", " + this.AutoScrollOffset.Y.ToString());
			CheckerboardRenderer.DrawCheckerboard(
				graphics, 
				this.AutoScrollOffset,
				e.ClipRectangle,
				new Size(50, 50)
				);
			StaticBoxRenderer.DrawBoxes(graphics, new Point(0, this.AutoScrollOffset.Y), 100, 30);
		}
	}
	public static class CheckerboardRenderer
	{
		public static void DrawCheckerboard(Graphics g, Point origin, Rectangle bounds, Size squareSize)
		{
			var numSquaresH = (bounds.Width + squareSize.Width - 1) / squareSize.Width + 1;
			var numSquaresV = (bounds.Height + squareSize.Height - 1) / squareSize.Height + 1;
			var startBoxH = (bounds.X - origin.X) / squareSize.Width;
			var startBoxV = (bounds.Y - origin.Y) / squareSize.Height;
			for (int i = startBoxH; i < startBoxH + numSquaresH; i++)
			{
				for (int j = startBoxV; j < startBoxV + numSquaresV; j++)
				{
					if ((i + j) % 2 == 0)
					{
						Random random = new Random(i * j);
						var color = Color.FromArgb(random.Next(70, 95), random.Next(70, 95), random.Next(70, 95));
						var brush = new SolidBrush(color);
						g.FillRectangle(brush, i * squareSize.Width + origin.X, j * squareSize.Height + origin.Y, squareSize.Width, squareSize.Height);
						brush.Dispose();
					}
				}
			}
		}
	}
	public static class StaticBoxRenderer
	{
		public static void DrawBoxes(Graphics g, Point origin, int boxWidth, int boxHeight)
		{
			int height = origin.Y;
			int left = origin.X;
			for (int i = 0; i < 25; i++)
			{
				Rectangle r = new Rectangle(left, height, boxWidth, boxHeight);
				g.FillRectangle(Brushes.White, r);
				g.DrawRectangle(Pens.Black, r);
				height += boxHeight;
			}
		}
	}
