    public static class DataGridRowEx
	{
		public static bool GetCanSelect(DependencyObject obj)
		{
			return (bool)obj.GetValue(CanSelectProperty);
		}
		public static void SetCanSelect(DependencyObject obj, bool value)
		{
			obj.SetValue(CanSelectProperty, value);
		}
		public static readonly DependencyProperty CanSelectProperty =
			DependencyProperty.RegisterAttached("CanSelect", typeof(bool), typeof(DataGridRowEx), new UIPropertyMetadata(true, OnCanSelectChanged));
		private static void OnCanSelectChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			var item = sender as DataGridRow;
			if (item == null)
				return;
			if ((bool)args.NewValue)
			{
				item.Selected -= RowSelected;
			}
			else
			{
				item.Selected += RowSelected;
				item.IsSelected = false;
			}
		}
		private static void RowSelected(object sender, RoutedEventArgs e)
		{
			var item = sender as DataGridRow;
			if (item == null)
				return;
			item.Dispatcher.BeginInvoke((Action)(()=>
			item.IsSelected = false));
		}
	}
