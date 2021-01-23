    public static class TextBoxSelectAllOnFocusBehaviorExtension
	{
		public static bool GetApply(DependencyObject obj)
		{
			return (bool)obj.GetValue(ApplyProperty);
		}
		public static void SetApply(DependencyObject obj, bool value)
		{
			obj.SetValue(ApplyProperty, value);
		}
		public static readonly DependencyProperty ApplyProperty =
			DependencyProperty.RegisterAttached("Apply", typeof(bool), typeof(TextBoxSelectAllOnFocusBehaviorExtension), new PropertyMetadata(false, OnApplyChanged));
		private static void OnApplyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			var behaviors = Interaction.GetBehaviors(sender);
			// Remove the existing behavior instances
			foreach (var old in behaviors.OfType<TextBoxSelectAllOnFocusBehavior>().ToArray())
				behaviors.Remove(old);
			if ((bool)args.NewValue)
			{
				// Creates a new behavior and attaches to the target
				var behavior = new TextBoxSelectAllOnFocusBehavior();
				// Apply the behavior
				behaviors.Add(behavior);
			}
		}
	}
