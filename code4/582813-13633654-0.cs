	public class HackyMess 
	{
        public static String GetCaption(DependencyObject obj)
		{
			return (String)obj.GetValue(CaptionProperty);
		}
		public static void SetCaption(DependencyObject obj, String value)
		{
			Debug.WriteLine("obj '{0}' setting caption to '{1}'", obj, value);
			obj.SetValue(CaptionProperty, value);
		}
		public static readonly DependencyProperty CaptionProperty =
			DependencyProperty.RegisterAttached("Caption", typeof(String), typeof(HackyMess),
				new FrameworkPropertyMetadata(null));
		public static object GetContext(DependencyObject obj) { return obj.GetValue(ContextProperty); }
		public static void SetContext(DependencyObject obj, object value) { obj.SetValue(ContextProperty, value); }
		public static void SetBackground(DependencyObject obj, Brush value) { obj.SetValue(BackgroundProperty, value); }
		public static Brush GetBackground(DependencyObject obj) { return (Brush) obj.GetValue(BackgroundProperty); }
		public static readonly DependencyProperty ContextProperty = DependencyProperty.RegisterAttached(
			"Context", typeof(object), typeof(HackyMess),
			new FrameworkPropertyMetadata(default(HackyMess), FrameworkPropertyMetadataOptions.OverridesInheritanceBehavior | FrameworkPropertyMetadataOptions.Inherits));
		public static readonly DependencyProperty BackgroundProperty = DependencyProperty.RegisterAttached(
			"Background", typeof(Brush), typeof(HackyMess),
			new UIPropertyMetadata(default(Brush), OnBackgroundChanged));
		private static void OnBackgroundChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			var rawValue = args.NewValue;
			if (rawValue is Brush)
			{
				var brush = rawValue as Brush;
				var previousContext = obj.GetValue(ContextProperty);
				if (previousContext != null && previousContext != DependencyProperty.UnsetValue)
				{
					if (brush is VisualBrush)
					{
						// If our hosted visual is a framework element, set it's data context to our inherited one
						var currentVisual = (brush as VisualBrush).GetValue(VisualBrush.VisualProperty);
						if(currentVisual is FrameworkElement)
						{
							(currentVisual as FrameworkElement).SetValue(FrameworkElement.DataContextProperty, previousContext);
						}
					}
				}
				// Why can't there be just *one* background property? *sigh*
				if (obj is TextBlock) { obj.SetValue(TextBlock.BackgroundProperty, brush); }
				else if (obj is Control) { obj.SetValue(Control.BackgroundProperty, brush); }
				else if (obj is Panel) { obj.SetValue(Panel.BackgroundProperty, brush); }
				else if (obj is Border) { obj.SetValue(Border.BackgroundProperty, brush); }
			}
		}
	}
