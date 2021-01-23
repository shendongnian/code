	public class Coordinates : DependencyObject
	{
		public Coordinates(double x, double y)
		{
			X = x;
			Y = y;
		}
		public Coordinates()
		{
			X = 0;
			Y = 0;
		}
		//X Dependency Property
		public double X
		{
			get { return (double)GetValue(XProperty); }
			set { SetValue(XProperty, value); }
		}
		public static readonly DependencyProperty XProperty =
			DependencyProperty.Register("X", typeof(double), typeof(Coordinates), new UIPropertyMetadata(0d));
		//Y Dependency Property
		public double Y
		{
			get { return (double)GetValue(YProperty); }
			set { SetValue(YProperty, value); }
		}
		public static readonly DependencyProperty YProperty =
			DependencyProperty.Register("Y", typeof(double), typeof(Coordinates), new UIPropertyMetadata(0d));
	}
