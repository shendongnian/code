	public static class TextboxExtensions
	{
		public static readonly DependencyProperty PlaceholderProperty = 
			DependencyProperty.RegisterAttached(
				"Placeholder", 
				typeof(string), 
				typeof(TextboxExtensions), 
				new PropertyMetadata(default(string), propertyChangedCallback: PlaceholderChanged)
				);
		private static void PlaceholderChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			var tb = dependencyObject as TextBox;
			
			if (tb == null)
				return;
			tb.LostFocus -= OnLostFocus;
			tb.GotFocus -= OnGotFocus;
			if (args.NewValue != null)
			{
				tb.GotFocus += OnGotFocus;
				tb.LostFocus += OnLostFocus;
			}
			SetPlaceholder(dependencyObject, args.NewValue as string);
			
			if (!tb.IsFocused)
				ShowPlaceholder(tb);
		}
		private static void OnLostFocus(object sender, RoutedEventArgs routedEventArgs)
		{
			ShowPlaceholder(sender as TextBox);
		}
		private static void OnGotFocus(object sender, RoutedEventArgs routedEventArgs)
		{
			HidePlaceholder(sender as TextBox);
		}
		[AttachedPropertyBrowsableForType(typeof(TextBox))]
		public static void SetPlaceholder(DependencyObject element, string value)
		{
			element.SetValue(PlaceholderProperty, value);
		}
		[AttachedPropertyBrowsableForType(typeof(TextBox))]
		public static string GetPlaceholder(DependencyObject element)
		{
			return (string)element.GetValue(PlaceholderProperty);
		}
		private static void ShowPlaceholder(TextBox textBox)
		{
			if (string.IsNullOrWhiteSpace(textBox.Text))
			{
				textBox.Text = GetPlaceholder(textBox);
			}
		}
		private static void HidePlaceholder(TextBox textBox)
		{
			string placeholderText = GetPlaceholder(textBox);
			if (textBox.Text == placeholderText)
				textBox.Text = string.Empty;
		}
	}
