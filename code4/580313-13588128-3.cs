    public class ListBoxItemEx
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
			DependencyProperty.RegisterAttached("CanSelect", typeof(bool), typeof(ListBoxItemEx), new UIPropertyMetadata(true, OnCanSelectChanged));
		private static void OnCanSelectChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			var item = sender as ListBoxItem;
			if (item == null)
				return;
			if ((bool)args.NewValue)
			{
				item.Selected -= ListBoxItemSelected;
			}
			else
			{
				item.Selected += ListBoxItemSelected;
				item.IsSelected = false;
			}
		}
		private static void ListBoxItemSelected(object sender, RoutedEventArgs e)
		{
			var item = sender as ListBoxItem;
			if (item == null)
				return;
			item.IsSelected = false;
		}
	}
