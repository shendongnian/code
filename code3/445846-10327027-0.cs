	public static class GridEx
	{
		public static readonly DependencyProperty RowFromBottomProperty = DependencyProperty.RegisterAttached("RowFromBottom", typeof(int?), typeof(GridEx), new FrameworkPropertyMetadata(default(int?), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsParentArrange | FrameworkPropertyMetadataOptions.AffectsParentMeasure, OnRowFromBottomChanged));
		public static readonly DependencyProperty RowSpanFromBottomProperty = DependencyProperty.RegisterAttached("RowSpanFromBottom", typeof(int?), typeof(GridEx), new FrameworkPropertyMetadata(default(int?), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsParentArrange | FrameworkPropertyMetadataOptions.AffectsParentMeasure, OnRowSpanFromBottomChanged));
		private static void OnRowFromBottomChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var grid = GetContainingGrid(d);
			int? rowFromBottom = (int?) e.NewValue;
			int? rowSpanFromBottom = GetRowSpanFromBottom(d);
			if (rowFromBottom == null || rowSpanFromBottom == null) return;
			int rows = grid.RowDefinitions.Count;
			int row = Math.Max(0, Math.Min(rows, rows - rowFromBottom.Value - rowSpanFromBottom.Value));
			Grid.SetRow((UIElement) d, row);
		}
		private static void OnRowSpanFromBottomChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var grid = GetContainingGrid(d);
			int? rowFromBottom = GetRowFromBottom(d);
			int? rowSpanFromBottom = (int?)e.NewValue;
			if (rowFromBottom == null || rowSpanFromBottom == null) return;
			int rows = grid.RowDefinitions.Count;
			int row = Math.Max(0, Math.Min(rows, rows - rowFromBottom.Value - rowSpanFromBottom.Value));
			Grid.SetRow((UIElement)d, row);
			Grid.SetRowSpan((UIElement)d, rowSpanFromBottom.Value);
		}
		public static int? GetRowFromBottom(DependencyObject obj)
		{
			return (int?) obj.GetValue(RowFromBottomProperty);
		}
		public static void SetRowFromBottom(DependencyObject obj, int? value)
		{
			obj.SetValue(RowFromBottomProperty, value);
		}
		public static int? GetRowSpanFromBottom(DependencyObject obj)
		{
			return (int?)obj.GetValue(RowSpanFromBottomProperty);
		}
		public static void SetRowSpanFromBottom(DependencyObject obj, int? value)
		{
			obj.SetValue(RowSpanFromBottomProperty, value);
		}
		private static Grid GetContainingGrid(DependencyObject element)
		{
			Grid grid = null;
			while (grid == null && element != null)
			{
				element = LogicalTreeHelper.GetParent(element);
				grid = element as Grid;
			}
			return grid;
		}
	}
