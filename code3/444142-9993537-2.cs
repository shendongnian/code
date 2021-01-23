    	public virtual void DefineDefaultValue(object default)
		{
			defaultValue = default;
                        OnPropertyChanged("MyProperty");
		}
		static object defaultValue;
		public static object Define()
		{
			return defaultValue;
		}
		public int MyProperty
		{
			get { return (int)GetValue(MyPropertyProperty); }
			set { SetValue(MyPropertyProperty, value); }
		}
		// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MyPropertyProperty =
			DependencyProperty.Register("MyProperty", typeof(int), typeof(MainMenuBase), new PropertyMetadata((int)Define()));
