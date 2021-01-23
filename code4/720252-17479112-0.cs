    public static class ContentTemplate
	{
		public static object GetContentTemplateKey(DependencyObject obj)
		{
			return (object)obj.GetValue(ContentTemplateKeyProperty);
		}
		public static void SetContentTemplateKey(DependencyObject obj, object value)
		{
			obj.SetValue(ContentTemplateKeyProperty, value);
		}
		public static readonly DependencyProperty ContentTemplateKeyProperty = DependencyProperty.RegisterAttached("ContentTemplateKey", typeof(object), typeof(ContentTemplate), new UIPropertyMetadata(null, OnContentTemplateKeyChanged));
		private static void OnContentTemplateKeyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var key = e.NewValue;
			var element = d as FrameworkElement;
			if (element == null)
				return;
			element.SetResourceReference(ContentControl.ContentTemplateProperty, key);
		}
	}
