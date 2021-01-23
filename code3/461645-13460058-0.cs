		public Object DataSource
		{
			get { return (Object)GetValue(DataSourceProperty); }
			set { SetValue(DataSourceProperty, value); }
		}
		public static readonly DependencyProperty DataSourceProperty =
			DependencyProperty.Register("DataSource", typeof(Object), typeof(DataContextProxy), null);
		protected override void OnAttached()
		{
			base.OnAttached();
			// Binds the target datacontext to the proxy,
			// so whenever it changes the proxy will be updated
			var binding = new Binding();
			binding.Source = this.AssociatedObject;
			binding.Path = new PropertyPath("DataContext");
			binding.Mode = BindingMode.OneWay;
			BindingOperations.SetBinding(this, DataContextProxyBehavior.DataSourceProperty, binding);
			// Add the proxy to the resource collection of the target
			// so it will be available to nested controls
			this.AssociatedObject.Resources.Add(
				"DataContextProxy",
				this
			);
		}
		protected override void OnDetaching()
		{
			base.OnDetaching();
			// Removes the proxy from the Resources
			this.AssociatedObject.Resources.Remove(
				"DataContextProxy"
			);
		}
	}
