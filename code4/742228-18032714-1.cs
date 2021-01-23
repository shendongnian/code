	public static class ScrollViewerBinding
	{
		public static double GetHorizontalOffset(DependencyObject depObj)
		{
			return (double)depObj.GetValue(HorizontalOffsetProperty);
		}
		public static void SetHorizontalOffset(DependencyObject depObj, double value)
		{
			depObj.SetValue(HorizontalOffsetProperty, value);
		}
		public static readonly DependencyProperty HorizontalOffsetProperty =
			DependencyProperty.RegisterAttached("HorizontalOffset",
                                                typeof(double),
												typeof(ScrollViewerBinding),
												new PropertyMetadata(OnHorizontalOffsetPropertyChanged));
		private static void OnHorizontalOffsetPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ScrollViewer sv = d as ScrollViewer;
			if (sv != null)
			{
				sv.ScrollToHorizontalOffset((double)e.NewValue);
			}
		}
	}
