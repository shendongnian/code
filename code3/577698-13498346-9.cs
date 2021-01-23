    public static class TextBoxEx
	{
		public static bool GetSelectAllOnFocus(DependencyObject obj)
		{
			return (bool)obj.GetValue(SelectAllOnFocusProperty);
		}
		public static void SetSelectAllOnFocus(DependencyObject obj, bool value)
		{
			obj.SetValue(SelectAllOnFocusProperty, value);
		}
		public static readonly DependencyProperty SelectAllOnFocusProperty =
			DependencyProperty.RegisterAttached("SelectAllOnFocus", typeof(bool), typeof(TextBoxSelectAllOnFocusBehaviorExtension), new PropertyMetadata(false, OnSelectAllOnFocusChanged));
		private static void OnSelectAllOnFocusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
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
