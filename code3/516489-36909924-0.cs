	public static class TextboxExtensions
	{
		public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.RegisterAttached(
			"Placeholder", typeof(string), typeof(TextboxExtensions), new PropertyMetadata(default(string), propertyChangedCallback: PlaceholderChanged));
		private static void PlaceholderChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			var tb = dependencyObject as TextBox;
			if(tb == null)
				return;
			tb.LostFocus -= OnLostFocus;
			tb.GotFocus -= OnGotFocus;
			if (args.NewValue != null)
			{
				tb.GotFocus += OnGotFocus;
				tb.LostFocus += OnLostFocus;
			}
		}
		private static void OnLostFocus(object sender, RoutedEventArgs routedEventArgs)
		{
			var tb = sender as TextBox;
			if (string.IsNullOrEmpty(tb.Text) || string.IsNullOrWhiteSpace(tb.Text))
			{
				tb.Text = GetPlaceholder(tb);
			}
		}
		private static void OnGotFocus(object sender, RoutedEventArgs routedEventArgs)
		{
			var tb = sender as TextBox;
			var ph = GetPlaceholder(tb);
			if (tb.Text == ph)
			{
				tb.Text = string.Empty;
			}
		}
		[AttachedPropertyBrowsableForType(typeof(TextBox))]
		public static void SetPlaceholder(DependencyObject element, string value)
		{
			element.SetValue(PlaceholderProperty, value);
		}
		[AttachedPropertyBrowsableForType(typeof(TextBox))]
		public static string GetPlaceholder(DependencyObject element)
		{
			return (string) element.GetValue(PlaceholderProperty);
		}
	}
