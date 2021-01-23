		public static readonly DependencyProperty FocusedAdapterProperty;
		static SpreadGridControl()
		{
			FocusedAdapterProperty = DependencyProperty.Register("FocusedAdapter",
								typeof(object), typeof(SpreadGridControl),
								new FrameworkPropertyMetadata(null, null));
		}
		public object FocusedAdapter
		{
			get { return GetValue(FocusedAdapterProperty); }
			set { SetValue(FocusedAdapterProperty, value); }
		}
