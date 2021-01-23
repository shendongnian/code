	public class Margin
	{
		public static readonly DependencyProperty LeftProperty = DependencyProperty.RegisterAttached(
			"Left",
			typeof(double),
			typeof(Margin),
			new PropertyMetadata(0.0, LeftChanged));
		private static void LeftChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var frameworkElement = d as FrameworkElement;
			if (frameworkElement != null)
			{
				Thickness currentMargin = frameworkElement.Margin;
				frameworkElement.Margin = new Thickness((double)e.NewValue, currentMargin.Top, currentMargin.Right, currentMargin.Bottom);
			}
		}
		public static void SetLeft(UIElement element, double value)
		{
			element.SetValue(LeftProperty, value);
		}
		public static double GetLeft(UIElement element)
		{
			return 0;
		}
		public static readonly DependencyProperty TopProperty = DependencyProperty.RegisterAttached(
			"Top",
			typeof(double),
			typeof(Margin),
			new PropertyMetadata(0.0, TopChanged));
		private static void TopChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var frameworkElement = d as FrameworkElement;
			if (frameworkElement != null)
			{
				Thickness currentMargin = frameworkElement.Margin;
				frameworkElement.Margin = new Thickness(currentMargin.Left, (double)e.NewValue, currentMargin.Right, currentMargin.Bottom);
			}
		}
		public static void SetTop(UIElement element, double value)
		{
			element.SetValue(TopProperty, value);
		}
		public static double GetTop(UIElement element)
		{
			return 0;
		}
		public static readonly DependencyProperty RightProperty = DependencyProperty.RegisterAttached(
			"Right",
			typeof(double),
			typeof(Margin),
			new PropertyMetadata(0.0, RightChanged));
		private static void RightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var frameworkElement = d as FrameworkElement;
			if (frameworkElement != null)
			{
				Thickness currentMargin = frameworkElement.Margin;
				frameworkElement.Margin = new Thickness(currentMargin.Left, currentMargin.Top, (double)e.NewValue, currentMargin.Bottom);
			}
		}
		public static void SetRight(UIElement element, double value)
		{
			element.SetValue(RightProperty, value);
		}
		public static double GetRight(UIElement element)
		{
			return 0;
		}
		public static readonly DependencyProperty BottomProperty = DependencyProperty.RegisterAttached(
			"Bottom",
			typeof(double),
			typeof(Margin),
			new PropertyMetadata(0.0, BottomChanged));
		private static void BottomChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var frameworkElement = d as FrameworkElement;
			if (frameworkElement != null)
			{
				Thickness currentMargin = frameworkElement.Margin;
				frameworkElement.Margin = new Thickness(currentMargin.Left, currentMargin.Top, currentMargin.Right, (double)e.NewValue);
			}
		}
		public static void SetBottom(UIElement element, double value)
		{
			element.SetValue(BottomProperty, value);
		}
		public static double GetBottom(UIElement element)
		{
			return 0;
		}
	}
